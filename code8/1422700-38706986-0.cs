    public class SampleClass
    {
        public IEnumerable<SampleItem> columns { get; set; }
        public IEnumerable<IEnumerable<string>> data { get; set; }
    }
    public class SampleItem
    {
        public string title { get; set; }
    }
