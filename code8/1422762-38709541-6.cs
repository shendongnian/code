    public class Stats : Dictionary<string, double>
    {
        public static explicit operator Stats(Dictionary<string, double> source)
        {
            Stats result = new Stats();
            foreach (var kvp in source)
            {
                result.Add(kvp.Key, kvp.Value);
            }
            return result;
        }
    }
