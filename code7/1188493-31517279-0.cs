    public class Root
    {
        public int ErrorCode { get; set; }
        public Dictionary<string, Entry> Entries { get; set; }
    }
    public class Entry
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    ...
    Root root = JsonConvert.DeserializeObject<Root>(json);
