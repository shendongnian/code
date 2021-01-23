    class ResultRow
    {
        public ResultRow()
        {
            Students = new Dictionary<string, string>();
        }
        public string Class { get; set; }
        public IDictionary<string, string> Students { get; set; }
    }
