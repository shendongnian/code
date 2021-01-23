    public sealed class HistoryEntry
    {
        private readonly DateTime timestamp;
        private readonly string url;
        public DateTime Timestamp { get { return timestamp; } }
        public string Url { get { return url; } }
    
        public HistoryEntry(DateTime timestamp, string url)
        {
            this.timestamp = timestamp;
            this.url = url;
        }
    }
