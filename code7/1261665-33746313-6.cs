        public class ConfigurationConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(Configuration).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var config = (existingValue as Configuration ?? (Configuration)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
                if (config.MyThreeTuple != null)
                    config.MyThreeTuple.Clear();
                serializer.Populate(reader, config);
                return config;
            }
            public override bool CanWrite { get { return false; } }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    Then use it with the following [`JsonSerializerSettings`](http://www.newtonsoft.com/json/help/html/serializationsettings.htm):
        var settings = new JsonSerializerSettings { Converters = new JsonConverter[] { new ConfigurationConverter() } };
