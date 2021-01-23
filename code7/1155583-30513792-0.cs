    public class KindOfUnknown
    {
        private Dictionary<string, object> _metadata = new Dictionary<string, object>();
        public object KnownValue1 { get; set; }
        public object KnownValue2 { get; set; }
        public object KnownValue3 { get; set; }
        public object this[string propertyName]
        {
            get { return _metadata[propertyName]; }
            set
            {
                _metadata[propertyName] = value;
            }
        }
        public bool ContainsProperty(string propertyName)
        {
            return _metadata.ContainsKey(propertyName);
        }
    }
