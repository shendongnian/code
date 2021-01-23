        private double Days360(DateTime StartDate, DateTime EndDate)
       {
        int StartDay = StartDate.Day;
        int StartMonth = StartDate.Month;
        int StartYear = StartDate.Year;
        int EndDay = EndDate.Day;
        int EndMonth = EndDate.Month;
        int EndYear = EndDate.Year;
        if (StartDay == 31 || IsLastDayOfFebruary(StartDate))
        {
            StartDay = 30;
        }
        if (StartDay == 30 && EndDay == 31)
        {
            EndDay = 30;
        }
        return ((EndYear - StartYear) * 360) + ((EndMonth - StartMonth) * 30) + (EndDay - StartDay);
    }
    private bool IsLastDayOfFebruary(DateTime date)
    {
        return date.Month == 2 && date.Day == DateTime.DaysInMonth(date.Year, date.Month);
    }
