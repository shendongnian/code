    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        public sealed class TimeRange
        {
            public DateTime Start { get; private set; }
            public DateTime End   { get; private set; }
            public TimeRange(string start, string end)
            {
                Start = DateTime.Parse(start);
                End   = DateTime.Parse(end);
            }
        }
        internal class Program
        {
            public static void Main()
            {
                var periods = new []
                {
                    new TimeRange("01/01/15", "11/01/15"), 
                    new TimeRange("02/01/15", "04/01/15"),
                    new TimeRange("09/01/15", "13/01/15"),
                    new TimeRange("18/01/15", "20/01/15")
                };
                Console.WriteLine(CountDays(periods));
            }
            public static int CountDays(IEnumerable<TimeRange> periods)
            {
                var usedDays = new HashSet<DateTime>();
                foreach (var period in periods)
                    for (var day = period.Start; day < period.End; day += TimeSpan.FromDays(1))
                        usedDays.Add(day);
                return usedDays.Count;
            }
        }
    }
