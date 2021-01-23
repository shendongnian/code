    public static class JsonHelper
    {
        public static string SerializeDictionary(Dictionary<string, string> dict, IEnumerable<string> intKeys)
        {
            JObject obj = new JObject();
            foreach (var kvp in dict)
            {
                int intValue;
                if (intKeys.Contains(kvp.Key) && int.TryParse(kvp.Value, out intValue))
                    obj.Add(kvp.Key, intValue);
                else
                    obj.Add(kvp.Key, kvp.Value);
            }
            return obj.ToString(Formatting.Indented);
        }
    }
