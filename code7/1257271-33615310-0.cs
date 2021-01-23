    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    
    namespace Sandbox
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<DateTime> dates = new List<DateTime>();
                dates.Add(new DateTime(2014, 1, 1));
                dates.Add(new DateTime(2014, 1, 2));
                dates.Add(new DateTime(2014, 1, 8));
                dates.Add(new DateTime(2014, 1, 10));
                dates.Add(new DateTime(2014, 1, 11));
                dates.Add(new DateTime(2014, 1, 12));
    
    
                var values = 
                dates.Select(dt => new DateRange(dt, dt))
                    .Distinct(new DateConsecutiveComparer()).ToArray();
                
                foreach (var range in values)
                {
                    Console.WriteLine(range);
                }
    
                Console.ReadKey();
            }
        }
    
        public class DateRange
        {
            public DateTime End { get; set; }
            public DateTime Start { get; set; }
    
            public DateRange(DateTime end, DateTime start)
            {
                End = end;
                Start = start;
            }
    
            public override string ToString()
            {
                if (Start == End)
                    return "[" + Start.ToString("MM/dd/yyyy") + "]";
                return "[" + Start.ToString("MM/dd/yyyy") + "," + End.ToString("MM/dd/yyyy") + "]";
            }
    
            public override int GetHashCode()
            {
                return Tuple.Create(Start, End).GetHashCode();
            }
        }
    
        public class DateConsecutiveComparer : IEqualityComparer<DateRange>
        {
            public bool Equals(DateRange x, DateRange y)
            {
                if (x.End.AddDays(1) == y.Start)
                {
                    x.End = y.End;
                    return true;
                }
                else if (y.End.AddDays(1) == x.Start)
                {
                    y.End = x.End;
                    return true;
                }
    
                else
                    return false;
            }
    
            public int GetHashCode(DateRange obj)
            {
                return 1;
            }
        }
    }
