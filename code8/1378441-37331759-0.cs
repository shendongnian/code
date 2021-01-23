    public class Model
    {
        private readonly Dictionary<string, int> pairs = new Dictionary<string, int>();
    
        public void Add(string key, int value)
        {
            pairs[key] = value;
        }
    
        public IEnumerable<KeyValuePair<string, int>> GetPairs()
        {
            return from pair in pairs
                   where pair.Value > 0 && string.IsNullOrEmpty(pair.Key) == false
                   select pair;
        }
    }
