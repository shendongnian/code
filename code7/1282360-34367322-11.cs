    using System;
    using System.Globalization;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var year = DateTime.Today.Year;
            var Jan1 = new DateTime(year, 1, 1);
            var dayNames = Enumerable.Range(0, 7).Select(d => Jan1.AddDays(d).ToString("dddd")).ToArray();
            var monthNames = Enumerable.Range(1,12).Select(m => new DateTime(year, m, 1).ToString("MMM")).ToArray();
         
            var dayOfYear = 0;
            foreach (var month in Enumerable.Range(1, 12))
            {
                foreach (var dayOfMonth in Enumerable.Range(1, DateTime.DaysInMonth(year, month)))
                {
                    Console.WriteLine("{0} {1} {2}", dayNames[dayOfYear % 7], monthNames[month-1], dayOfMonth);
                    dayOfYear++;
                }  
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey(true);
            }
        }
    }
