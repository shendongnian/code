    public static class JsonHelper
    {
        public static JsonSerializerSettings DefaultSerializerSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    Converters = new JsonConverter[] { new BarConverter(), new BarAJsonConverter() }
                };
            }
        }
    }
