    public static class JsonExtensions
    {
        public static void Populate<T>(this JToken value, T target)
        {
            using (var sr = value.CreateReader())
            {
                JsonSerializer.CreateDefault().Populate(sr, target); // Uses the system default JsonSerializerSettings
            }
        }
    }
