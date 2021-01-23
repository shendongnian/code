    public class DictionaryComparer : IEqualityComparer<KeyValuePair<string, string>>
    {
        public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            return x.Key.Equals(y.Key) 
                && x.Value.Equals(y.Value);
        }
        public int GetHashCode(KeyValuePair<string, string> obj)
        {
            return string.Concat(obj.Key, obj.Value)
                .GetHashCode();
        }
    }
