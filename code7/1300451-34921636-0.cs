    public class ResponseModel
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }
    public class Champion
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
