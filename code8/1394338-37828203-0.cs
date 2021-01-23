    class ResultRow
    {
        public ResultRow()
        {
            Students = new Dictionary<string, bool>();
        }
        public string Class { get; set; }
        public IDictionary<string, bool> Students { get; set; }
    }
