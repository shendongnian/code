    public List<int> Weeks(DateTime start, DateTime end)
    {
        List<int> weeks=new List<int>();
        var Week=(int)Math.Floor((double)start.DayOfYear/7.0); //starting week number
        for (DateTime t = start; t < end; t = t.AddDays(7))
        {
            weeks.Add(Week);
            Week++;
        }
        return weeks;
    }
