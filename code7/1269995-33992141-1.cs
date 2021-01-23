    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication59
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime time = DateTime.ParseExact(("26-12-2017 5:45pm").ToUpper(),"dd-MM-yyyy h:mmtt", CultureInfo.InvariantCulture);
                int dayOfWeek = (int)time.DayOfWeek;
                DateTime saturdaySundayMidnight = time.AddDays(-dayOfWeek).Date;
                TimeSpan timeOfWeek = time.Subtract(saturdaySundayMidnight);
                TimeSpan  startTime = new TimeSpan(1,17,45,0);  //Monday 5:45PM
                TimeSpan  endTime = new TimeSpan(3,18,0,0);  //Wednesday 6:00PM
                if ((timeOfWeek >= startTime) && (timeOfWeek <= endTime))
                {
                    Console.WriteLine("In Range");
                }
            }
        }
    }
