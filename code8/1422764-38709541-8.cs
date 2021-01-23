    public class Stats : Dictionary<string, double>
    {
        public static Stats FromDictionary(Dictionary<string, double> source)
        {
            Stats result = new Stats();
            foreach (var kvp in source)
            {
                result.Add(kvp.Key, kvp.Value);
            }
            return result;
        }
    }
