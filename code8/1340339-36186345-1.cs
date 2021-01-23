    public static class NewsExtensions
    {
        public static DateTime StartOfWeek(this News news)
        {
            int diff = news.Date.DayOfWeek - DayOfWeek.Monday;
            if (diff < 0)
            {
                diff += 7;
            }
            return news.Date.AddDays(-1 * diff).Date;
        }
    }
