    public List<string> FetchWeeks(int year)
    {
        List<string> weeks = new List<string>();
        DateTime startDate = new DateTime(year, 1, 1);
        startDate = startDate.AddDays(1 - (int)startDate.DayOfWeek);
        DateTime endDate = startDate.AddDays(6);
        while (startDate.Year < 1 + year)
        {
            weeks.Add(string.Format("Week: From {0:dd/MM/yyyy}to {1:dd/MM/yyyy}", startDate, endDate));
            startDate= startDate.AddDays(7);
            endDate = endDate.AddDays(7);
        }
        return weeks;
    }
