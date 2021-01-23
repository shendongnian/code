    public Dictionary<DateTime, int> GetCountByWeek(DateTime fromDate)
    {
        Dictionary<string, int> dict = session.Query<News>().ToList()
            .Where(n => n.Date > fromDate)
            .GroupBy(n => n.StartOfWeek())
            .ToDictionary(g => g.Key, g => g.Count());
        return dict;
    }
