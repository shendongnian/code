    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SkipWeekends
    {
        class Program
        {
            static List<DateTime> AddBusinessDays(DateTime startDate, int numDays)
            {
                var dates = new List<DateTime>();
    
                var step = (numDays < 0) ? -1 : 1;
                var date = startDate;
                var absNumDays = Math.Abs(numDays);
    
                while(dates.Count() < absNumDays)
                {
                    date = date.AddDays(step);
    
                    if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                        continue;
    
                    dates.Add(date);
                }
    
                return dates;
            }
    
            static void Main(string[] args)
            {
                var dates = new List<DateTime>();
                var start = DateTime.Now;
    
                dates = AddBusinessDays(start, 14);
    
                Console.WriteLine("14 Business Days in the Future:\n");
    
                foreach(var date in dates)
                {
                    Console.WriteLine(date.ToString());
                }
    
                dates = AddBusinessDays(start, -14);
    
                Console.WriteLine("\n\n14 Business Days in the Past:\n");
    
                foreach (var date in dates)
                {
                    Console.WriteLine(date.ToString());
                }
                
            }
        }
    }
