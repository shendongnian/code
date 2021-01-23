    using System.Diagnostics.Eventing.Reader;
    public class MyEventLogQuery
    {
        public string Log { get; set; }
        public PathType PathType { get; set; }
        public string Query { get; set; }
        public EventBookmark Bookmark { get; set; }
        public MyEventLogQuery(string log = "Application", PathType pathType = PathType.LogName, string query = "*[System[(Level=2)]]")
        {
            Log = log;
            PathType = pathType;
            Query = query;
            Bookmark = GetBookmark(log, pathType); // Query is not important here
        }
        // This method returns the bookmark of the most recent event
        // log EventRecord or null if the log is empty
        private static EventBookmark GetBookmark(string log, PathType pathType)
        {
            var elq = new EventLogQuery(log, pathType) {ReverseDirection = true};
            var reader = new EventLogReader(elq);
            var record = reader.ReadEvent();
            if (record != null)
                return record.Bookmark;
            return null;
        }
    }
