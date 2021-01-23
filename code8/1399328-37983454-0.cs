    public static class JsonExtensions
    {
        public static Dictionary<string, JToken> PropertiesByRegexp(this JObject token, Regex regex)
        {
            return token.Properties()
                .Where(p => regex.IsMatch(p.Name))
                .ToDictionary(p => p.Name, p => p.Value);
        }
    }
