    public class FeatureHistorgram : IDictionary<string, Historam>
    {
        private readonly Dictionary<string, Histogram> _data = new Dictionary<string, Histogram>();
    
        public void Add(string key, Histogram value)
        {
            _data.Add(key, value);
        }
    
        // ... and the rest of IDictionary<TKey, TValue> interface members...
    }
