    public class Info : Dictionary<string, Stats>
    {
        public static explicit operator Info(Dictionary<string, Dictionary<string, double>> source)
        {
            Info result = new Info();
            foreach (var kvp in source)
            {
                result.Add(kvp.Key, Stats.FromDictionary(kvp.Value));
            }
            return result;
        }
    }
