    static int GetLastXthWorkingDay(int year, int month, int x)
            {
                var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
    
                var holidays = new DateTime[] { 
                    new DateTime(year, 4, 6),
                    new DateTime(year, 5, 1), 
                    new DateTime(year, 5, 8), 
                    new DateTime(year, 7, 5), 
                    new DateTime(year, 7, 6), 
                    new DateTime(year, 9, 28), 
                    new DateTime(year, 10, 28), 
                    new DateTime(year, 11, 17), 
                    new DateTime(year, 12, 24), 
                    new DateTime(year, 12, 25), 
                    new DateTime(year, 12, 26), 
                };
    
                //Fetch the amount of days in your given month.
                int daysInMonth = DateTime.DaysInMonth(year, month);
    
                //Here we create an enumerable from 1 to daysInMonth,
                //and ask whether the DateTime object we create belongs to a weekend day,
                //if it doesn't, add it to our IEnumerable<int> collection of days.
                IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, daysInMonth)
                                                       .Where(d => !weekends.Contains(new DateTime(year, month, d).DayOfWeek));
    
                var lastXthWorkingDay = businessDaysInMonth.Skip(Math.Max(0, businessDaysInMonth.Count() - x));
                
                    foreach (var day in lastXthWorkingDay)
                    {
                        if ( holidays.Contains(new DateTime(year, month, day)) )
                        {
                            return GetLastXthWorkingDay(year, month, x + 1);
                            //return day-1;
                        }
                        else { return day; }
                    }
    
                    return 0;
            }
