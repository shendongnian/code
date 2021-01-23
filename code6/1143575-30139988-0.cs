    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication25
    {
        class Program
        {
     
            static void Main(string[] args)
            {
                List<string> dayNames = new List<string>(){"Mo","Tu","We","Th","Fr","Sa","So"};
                string input = "Mo-Fr 06:00-22:00, Sa 07:00-22:00, So 08:00-22:00";
                string[] days = input.Split(new char[] { ',' });
                var dayRange = (from d in days
                                select d.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                               .Select(x => new { days = x[0].Trim(), time = x[1].Trim() })
                               .Select(x => new {  
                                   startDay = x.days.Contains("-") ? x.days.Split(new char[] {'-'})[0] : x.days,
                                   endDay = x.days.Contains("-") ? x.days.Split(new char[] {'-'})[1] : x.days,
                                   startTime = x.time.Contains("-") ? x.time.Split(new char[] {'-'})[0] : x.time,
                                   endTime = x.time.Contains("-") ? x.time.Split(new char[] {'-'})[1] : x.time,
                               }); 
                 
                var period = dayRange.Select(x => new {
                    open = new {day = dayNames.IndexOf(x.startDay) + 1, time = x.startTime},
                    close = new {day = dayNames.IndexOf(x.endDay) + 1, time = x.endTime}
                });
            }
     
        }
     
    }
