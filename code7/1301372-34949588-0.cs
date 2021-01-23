    public class Test
    {
        public string col1 { get; set; }
        public string col2 { get; set; }
    }
    public class DataValue
    {
        public Test test { get; set; }
    }
    public class RootObject
    {
        public RootObject() { this.data = new Dictionary<string, DataValue>(); }
        public Dictionary<string, DataValue> data { get; set; }
    }
