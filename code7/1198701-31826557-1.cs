    public class DateAndWeek
    {
        public DateTime Date { get; set; }
        public int WeekNumber { get; set; }
    }
    private List<DateAndWeek> GetListOfDateAndWeek(int startYear, int startMonth, int startDay)
    {
        List<DateAndWeek> dateTimes = new List<DateAndWeek>();
        var week = 0;
        var dateTimeStart = new DateTime(startYear, startMonth, startDay);
        for (int i = 0; i < 365; i++)
        {
           var dateTime = dateTimeStart.AddDays(i);
           if (dateTime.DayOfWeek == DayOfWeek.Monday)
           {
              week++;
           }
           dateTimes.Add(new DateAndWeek { Date = dateTime, WeekNumber = week });
        }
        return dateTimes;
    }
