    public class MonthSummary
    {
        public DateTime Month { get; set; }
        public string MonthName { get { return Month.ToString("MMMM"); } }
        public string MonthClass { get; set; }
        public string ArchiveUrl { get; set; }
        public int NumberOfPosts { get; set; }
        public int ViewIndex { get; set; }
    }
