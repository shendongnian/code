        [JsonConverter(typeof(ConfigurationConverter))]
        public class Configuration
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            public MyEnumTypes Type { get; set; }
            public OptionalType TypeAdditionalData { get; set; }
            [JsonProperty(PropertyName = "value")]
            public int Value { get; set; }
        }
        class ConfigurationConverter : JsonConverter
        {
            const string typeName = "type";
            public override bool CanConvert(Type objectType)
            {
                return typeof(Configuration).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
                var config = (existingValue as Configuration ?? (Configuration)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
                // Populate the regular property values.
                var obj = JObject.Load(reader);
                var type = obj.RemoveProperty(typeName);
                using (var subReader = obj.CreateReader())
                    serializer.Populate(subReader, config);
                // Populate Type and OptionalType
                if (type is JValue) // Primitive value
                {
                    config.Type = type.ToObject<MyEnumTypes>(serializer);
                }
                else
                {
                    var dictionary = type.ToObject<Dictionary<MyEnumTypes, OptionalType>>(serializer);
                    if (dictionary.Count > 0)
                    {
                        config.Type = dictionary.Keys.First();
                        config.TypeAdditionalData = dictionary.Values.First();
                    }
                }
                return config;
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var config = (Configuration)value;
                var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(config.GetType());
                writer.WriteStartObject();
                foreach (var property in contract.Properties
                    .Where(p => p.Writable && (p.ShouldSerialize == null || p.ShouldSerialize(config)) && !p.Ignored))
                {
                    if (property.UnderlyingName == "Type" || property.UnderlyingName == "TypeAdditionalData")
                        continue;
                    var propertyValue = property.ValueProvider.GetValue(config);
                    if (propertyValue == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                        continue;
                    writer.WritePropertyName(property.PropertyName);
                    serializer.Serialize(writer, propertyValue);
                }
                writer.WritePropertyName(typeName);
                if (config.Type.GetCustomAttributeOfEnum<OptionalSettingsAttribute>() == null)
                {
                    serializer.Serialize(writer, config.Type);
                }
                else
                {
                    var dictionary = new Dictionary<MyEnumTypes, OptionalType>
                    {
                        { config.Type, config.TypeAdditionalData },
                    };
                    serializer.Serialize(writer, dictionary);
                }
                writer.WriteEndObject();
            }
        }
        public class OptionalType
        {
            public string setting1 { get; set; }
        }
        public class OptionalSettingsAttribute : System.Attribute
        {
            public OptionalSettingsAttribute()
            {
            }
        }
        [JsonConverter(typeof(StringEnumConverter))]
        public enum MyEnumTypes
        {
            [EnumMember(Value = "simple1")]
            Simple1,
            [EnumMember(Value = "simple2")]
            Simple2,
            [OptionalSettingsAttribute]
            [EnumMember(Value = "optional1")]
            Optional1,
            [EnumMember(Value = "optional2")]
            [OptionalSettingsAttribute]
            Optional2
        }
    
        public static class EnumExtensions
        {
            public static TAttribute GetCustomAttributeOfEnum<TAttribute>(this Enum value)
                where TAttribute : System.Attribute
            {
                var type = value.GetType();
                var memInfo = type.GetMember(value.ToString());
                return memInfo[0].GetCustomAttribute<TAttribute>();
            }
        }
        public static class JsonExtensions
        {
            public static JToken RemoveProperty(this JObject obj, string name)
            {
                if (obj == null)
                    return null;
                var property = obj.Property(name);
                if (property == null)
                    return null;
                var value = property.Value;
                property.Remove();
                property.Value = null;
                return value;
            }
        }
    Notice I added `[JsonConverter(typeof(StringEnumConverter))]` to your enum.  This ensures the type is always written as a string.
    Sample [fiddle](https://dotnetfiddle.net/9NisVT).
