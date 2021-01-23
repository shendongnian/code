    public static class CouchbaseClientExtensions
    {
        public static JsonSerializerSettings JsonSerializerSettings;
        static CouchbaseClientExtensions()
        {
            JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DocumentIdContractResolver()
                };
        }
        // ...
        private static string SerializeObject(object value)
        {
            var json = JsonConvert.SerializeObject(value,
                                    Formatting.None,
                                    JsonSerializerSettings);
            return json;
        }
    }
