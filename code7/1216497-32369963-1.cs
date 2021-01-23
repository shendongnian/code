    sealed class Request {
        public string Name { get; set; }
        public Dictionary<string, string> Args { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
