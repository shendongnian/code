    public Tuple<DateTime, DateTime> GetRange(string startDate, string endDate)
    {
        DateTime startDt;
        DateTime endDt;
        if (!DateTime.TryParse(startDate))
            startDate = DateTime.Now;
        if (string.IsNullOrEmpty(endDate) || !DateTime.TryParse(endDate))
            endDt = startDt.AddMinutes(Configuration.Instance.RecentOrdersWindowDurationMinutes);
        return new Tuple<DateTime, DateTime>(startDt, endDt);
    }
