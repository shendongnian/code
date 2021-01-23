    public static int WeekOf(String dateAsString)
                {
                   //if (!string.IsNullOrEmpty(dateAsString))
                    if (!dateAsString.equals(string.empty))
                    {
                        GregorianCalendar gCalendar = new GregorianCalendar();
                        int WeekNumber = gCalendar.GetWeekOfYear(date.Value,  CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        return WeekNumber;
                    }
                    else
                        return 0;
                }
