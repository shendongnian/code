    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    namespace ConsoleApplication56
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<DateTime> dates = new List<DateTime>(){
                    DateTime.Parse("01/01/2014"),
                    DateTime.Parse("02/01/2014"),
                    DateTime.Parse("08/01/2014"),
                    DateTime.Parse("10/01/2014"),
                    DateTime.Parse("11/01/2014"),
                    DateTime.Parse("12/01/2014")
                }.OrderBy(x => x).ToList();
                List<DateRange> ranges = new List<DateRange>();
                DateTime previousDate = new DateTime();
                DateRange newRange = null;
                for (int index = 0; index < dates.Count; index++)
                {
                    if (index == 0)
                    {
                        previousDate = dates[0];
                        newRange = new DateRange() { startDate = dates[index]};
                        ranges.Add(newRange);
                    }
                    else
                    {
                        if (index == dates.Count - 1)
                        {
                            if (IsConsecutive(previousDate, dates[index]))
                            {
                                newRange.endDate = dates[index];
                            }
                            else
                            {
                                if (index != 1)
                                {
                                    newRange.endDate = dates[index - 1];
                                }
                                newRange = new DateRange() { startDate = dates[index] };
                                ranges.Add(newRange);
                            }
                        }
                        else
                        {
                            if (!IsConsecutive(previousDate, dates[index]))
                            {
                                if (index != 1)
                                {
                                    if(newRange.startDate != dates[index - 1])
                                       newRange.endDate = dates[index - 1];
                                }
                                newRange = new DateRange() { startDate = dates[index] };
                                ranges.Add(newRange);
                            }
                            previousDate = dates[index];
                        }
                    }
                }
            }
            static Boolean IsConsecutive(DateTime firstDate, DateTime secondDate)
            {
                if((new DateTime(firstDate.Year, firstDate.Month, 1)).AddMonths(1) == (new DateTime(secondDate.Year, secondDate.Month, 1)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
        }
        public class DateRange
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
        }
    }
