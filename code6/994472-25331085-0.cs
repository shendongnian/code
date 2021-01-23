    var model = new List<EmployeeHolidayPeriodCalendarModel>();
    
                var actualDate = new DateTime(2013, 9, 1);
    
                // loop 12 months
                for (int index = 1; index <= 12; index++)
                {
                    var date = new DateTime(actualDate.Year, actualDate.Month, 1);
                    var monthInfo = new EmployeeHolidayPeriodCalendarModel();
                    monthInfo.Month = (byte)date.Month;
                    monthInfo.Year = date.Year;
                    monthInfo.WeekDayStart = Convert.ToByte(date.DayOfWeek); // 0 = Sunday....
                    monthInfo.DaysInMonth = Convert.ToByte(DateTime.DaysInMonth(date.Year, date.Month));
                    monthInfo.MonthName = date.ToString("MMM");
    
                    // increment date by adding months
                    actualDate= actualDate.AddMonths(1);
    
                    model.Add(monthInfo);
                }
                // the month where weekdaystart is first
                byte firstWeekDay = model.Min(m => m.WeekDayStart);
                byte lastWeekDay = model.Max(m => m.WeekDayStart);
                decimal maxDaysInMonth = model.Max(m => m.DaysInMonth);
    
                // calculate total model rows
                byte totalRows = Convert.ToByte((lastWeekDay - firstWeekDay)+maxDaysInMonth - 1);
    
                // fill each month data
                foreach (var month in model)
                {
                    month.Items = new List<PeriodCalendarRowModel>();
    
                    byte rowIndex = Convert.ToByte(month.WeekDayStart-firstWeekDay);
                    int negRowIndex = Convert.ToInt16(rowIndex * -1);
    
    
                    for (byte dayRow = 1; dayRow <= totalRows; dayRow++)
                    {
                        var day = dayRow + negRowIndex;
                        if (day < 1 || day > month.DaysInMonth)
                        {
                            // add empty data
                            var newDay = new PeriodCalendarRowModel();
                            newDay.Day = 0;
                            newDay.Month = month.Month;
                            newDay.RowIndex = dayRow;
    
                            month.Items.Add(newDay);
                        }
    
                        if (day >= 1 && day <= month.DaysInMonth)
                        {
                            // add normal data
                            var newDay = new PeriodCalendarRowModel();
                            newDay.Day = (byte)day;
                            newDay.Month = month.Month;
                            newDay.RowIndex = dayRow;
    
                            month.Items.Add(newDay);
                        }
                    }
                }
