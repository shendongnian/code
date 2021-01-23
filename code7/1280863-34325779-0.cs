    public static class JsonExtensions
    {
        public static void PopulateFromJson<T>(this T target, string json) where T : class
        {
            if (target == null || json == null)
                throw new ArgumentException();
            JsonConvert.PopulateObject(json, target);
        }
        public static void PopulateFromJson<T>(this T target, JToken json) where T : class
        {
            if (target == null || json == null)
                throw new ArgumentException();
            using (var reader = json.CreateReader())
                JsonSerializer.CreateDefault().Populate(reader, target);
        }
    }
