    // Extension methods to query or walk through nested properties, avoiding null reference exceptions when properties are missing
    public static class PropertyDataExtensions
    {
        public static IEnumerable<KeyValuePair<string, PropertyData>> GetProperties(this PropertyData data)
        {
            if (data == null || data.Properties == null)
                return Enumerable.Empty<KeyValuePair<string, PropertyData>>();
            return data.Properties;
        }
        public static PropertyData GetProperty(this PropertyData data, string name)
        {
            if (data == null || data.Properties == null)
                return null;
            PropertyData child;
            if (!data.Properties.TryGetValue(name, out child))
                return null;
            return child;
        }
    }
