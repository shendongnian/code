    public static class JsonExtensions
    {
        public static JObject WithProperty(this JObject obj, string name, JToken value)
        {
            obj = obj ?? new JObject();
            obj[name] = value;
            return obj;
        }
    }
