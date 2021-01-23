    public class RootObject
    {
        public RootObject() { this.data = new SortedDictionary<long, DataValue>(); }
        public SortedDictionary<long, DataValue> data { get; set; }
    }
