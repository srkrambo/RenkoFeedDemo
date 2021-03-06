﻿#region Copyright and Author Details
// Project: RenkoFeedDemo, Namespace: RenkoFeedDemo
// Copyright (C) 2016 SquidEyes, LLC.
// Written by Louis S. Berman <louis@squideyes.com>, 4/26/2016

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;

namespace RenkoFeedDemo
{
    public class Brick
    {
        internal Brick(DateTime? openOn, DateTime closeOn,
            double openRate, double closeRate)
        {
            OpenOn = openOn.Value;
            CloseOn = closeOn;
            OpenRate = openRate;
            CloseRate = closeRate;
        }

        public DateTime OpenOn { get; }
        public DateTime CloseOn { get;}
        public double OpenRate { get; }
        public double CloseRate { get;}

        public Trend Trend => (OpenRate < CloseRate) ?
            Trend.Rising : Trend.Falling;

        public override string ToString()
        {
            return string.Format(
                "{0} to {1} on {2}, Open: {3}, Close: {4}",
                OpenOn.ToTimeString(), CloseOn.ToTimeString(),
                OpenOn.ToDateString(), OpenRate, CloseRate);
        }

        public string ToCsvBar()
        {
            double highRate;
            double lowRate;

            if (Trend == Trend.Rising)
            {
                highRate = CloseRate;
                lowRate = OpenRate;
            }
            else
            {
                highRate = OpenRate;
                lowRate = CloseRate;
            }

            return string.Format("{0},{1},{2},{3},{4},{5}",
                OpenOn.ToDateTimeString(),
                CloseOn.ToDateTimeString(),
                OpenRate, highRate, lowRate, CloseRate);
        }
    }
}
