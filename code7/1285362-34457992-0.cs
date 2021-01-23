    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
        
            static void Main(string[] args)
            {
                List <TimeRange> timeRanges = new List<TimeRange>();
                timeRanges.Add(new TimeRange(TimeSpan.FromHours(5), TimeSpan.FromHours(6)));
                timeRanges.Add(new TimeRange(TimeSpan.FromHours(8), TimeSpan.FromHours(9)));
                List<Interval> intervals = new List<Interval>();
                intervals.Add(new Interval(TimeSpan.FromHours(1), TimeSpan.FromHours(7)));
                intervals.Add(new Interval(TimeSpan.FromHours(10), TimeSpan.FromHours(15)));
                var combinedTimeRanges = new List<TimeRange>();
                var overlaps = new List<TimeRange>();
                timeRanges.AddRange(intervals.Select(interval => new TimeRange(interval.start, interval.end)));
                foreach (var range in timeRanges)
                {
                    var olaps = timeRanges.Where(x => range != x && x.start < range.end && range.start < x.end).ToList();
                    if (olaps.Count > 0)
                    {
                        overlaps.AddRange(olaps);
                    }
                }
                overlaps = overlaps.OrderBy(x => x.start).ToList();
                if (overlaps.Count > 0 && overlaps.Count % 2 == 0)
                {
                    while (overlaps.Count > 0 && overlaps.Count % 2 == 0)
                    {
                        var first = overlaps[0];
                        var second = overlaps[1];
                        if (first.start < second.end && second.start < first.end)
                        {
                            var temp1 = new TimeRange(first.start, second.start);
                            var temp2 = new TimeRange(second.start, second.end);
                            var temp3 = new TimeRange(second.end, first.end);
                            timeRanges.Remove(first);
                            timeRanges.Remove(second);
                            timeRanges.Add(temp1);
                            timeRanges.Add(temp2);
                            timeRanges.Add(temp3);
                        }
                        else
                        {
                        
                        }
                        overlaps.Remove(first);
                        overlaps.Remove(second);
                    }
                }
            
                timeRanges.OrderBy(x => x.start).ToList().ForEach(x => Console.WriteLine($"{x.start} - {x.end}"));
              //  var examples = timeRanges.Where(x => timeRanges.Any(y => x.start < y.end && y.start < x.end)).ToList();
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
