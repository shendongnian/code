    using System;
    using System.Globalization;
    using System.Linq;
      
    class Program
    {
        static void Main(string[] args)
        {
            var year = DateTime.Today.Year;
            //FIRST DAY OF THE WEEK IS CUSTOMIZABLE/SYSTEM DEPENDANT!
            var dayOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + (int)(new DateTime(year, 1, 1).DayOfWeek) ;
            var dayNames = new string[] {"", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            var monthNames = new string[] { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
         
            var dayOfYear = 1;
            foreach (var month in Enumerable.Range(1, 12))
            {
                foreach (var dayOfMonth in Enumerable.Range(1, DateTime.DaysInMonth(year, month)))
                {
                    Console.WriteLine("{0} {1} {2}", dayNames[(dayOfYear % 7) + dayOffset], monthNames[month], dayOfMonth);
                    dayOfYear++;
                }  
                Console.WriteLine("Press a key to continue...");
                Console.ReadKey(true);
            }
        }
    }
