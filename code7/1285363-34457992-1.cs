    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                List<TimeRange> timeRanges = new List<TimeRange>();
                timeRanges.Add(new TimeRange(TimeSpan.FromHours(2), TimeSpan.FromHours(3)));
                timeRanges.Add(new TimeRange(TimeSpan.FromHours(8), TimeSpan.FromHours(9)));
                timeRanges.Add(new TimeRange(TimeSpan.FromHours(1), TimeSpan.FromHours(5)));
                timeRanges.Add(new TimeRange(TimeSpan.FromHours(3), TimeSpan.FromHours(6)));
                List<Interval> intervals = new List<Interval>();
                intervals.Add(new Interval(TimeSpan.FromHours(1), TimeSpan.FromHours(7)));
                intervals.Add(new Interval(TimeSpan.FromHours(10), TimeSpan.FromHours(15)));
                timeRanges.AddRange(intervals.Select(x => new TimeRange(x.start, x.end)));
                var times = new List<TimeSpan>();
                times.AddRange(timeRanges.Select(x => x.start));
                times.AddRange(timeRanges.Select(x => x.end));
                times = times.Distinct().OrderBy(x => x.Ticks).ToList();
                var ranges = new List<TimeRange>();
                while (times.Count > 1)
                {
                    ranges.Add(new TimeRange(times[0], times[1]));
                    times.RemoveAt(0);
                }
                ranges.ForEach(x => Console.WriteLine("{0} - {1}", x.start, x.end));
                Console.Read();
            }
        }
        public class TimeRange
        {
            public TimeSpan start { get; set; }
            public TimeSpan end { get; set; }
            public TimeRange(TimeSpan st, TimeSpan en)
            {
                start = st;
                end = en;
            }
        }
        public class Interval
        {
            public TimeSpan start { get; set; }
            public TimeSpan end { get; set; }
            public Interval(TimeSpan st, TimeSpan en)
            {
                start = st;
                end = en;
            }
        }
    }
