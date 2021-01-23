    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication38
    {
        class Program
        {
            static void Main(string[] args)
            {
                DateTime firstOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                DateTime lastDayOfMonth = firstOfMonth.AddMonths(1).AddDays(-1);
                List<DateTime> daysOfMonth = new List<DateTime>();
                for (DateTime dayCounter = firstOfMonth; dayCounter <= lastDayOfMonth; dayCounter = dayCounter.AddDays(1))
                {
                    daysOfMonth.Add(dayCounter);
                }
            }
        }
    }
