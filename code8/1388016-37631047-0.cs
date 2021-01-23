    using System;
    using System.Globalization;
    
    public class Test
    {
        static void Main()
        {
            var now = DateTime.Now;
            var calendar = new PersianCalendar();
            Console.WriteLine($"Year: {calendar.GetYear(now)}");
            Console.WriteLine($"Month: {calendar.GetMonth(now)}");
            Console.WriteLine($"Day: {calendar.GetDayOfMonth(now)}");
        }
    }
