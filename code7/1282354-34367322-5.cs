    using System;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var year = DateTime.Today.Year;
            foreach (var month in Enumerable.Range(1, 12))
            {
                foreach (var day in Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                          .Select(day => new DateTime(year, month, day).ToString("dddd MMM d")))
                {
                    Console.WriteLine(day);
                }  
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey(true);
            }
        }
    }
