    public Dictionary<DateTime, int> GetCountByWeek(DateTime fromDate)
    {
         var vals =
                from l in session.Query<News>().ToList()
                where l.Date > fromDate
                group l by MyMonday(l.Date.Date) // Use Date.Date to ignore any time values
                    into gr
                    select new { Key = gr.Key, Value = gr.Count() };
            return vals.ToDictionary(l => l.Key, l => l.Value);
    }
