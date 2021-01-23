    public class NullReportConverter : JsonConverter
    {
        private readonly List<PropertyInfo> _nullproperties=new List<PropertyInfo>();
        public bool ReportDefinedNullTokens { get; set; }
        public IEnumerable<PropertyInfo> NullProperties
        {
            get { return _nullproperties; }
        }
        public void Clear()
        {
            _nullproperties.Clear();
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            existingValue = existingValue ?? Activator.CreateInstance(objectType, true);
            var jObject = JObject.Load(reader);
            var properties =
                objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                var jToken = jObject[property.Name];
                if (jToken == null)
                {
                    _nullproperties.Add(property);
                    continue;
                }
                var value = jToken.ToObject(property.PropertyType);
                if(ReportDefinedNullTokens && value ==null)
                    _nullproperties.Add(property);
                property.SetValue(existingValue, value, null);
            }
            return existingValue;
        }
        //NOTE: we can omit writer part if we only want to use the converter for deserializing
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType();
            var properties =
                objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            writer.WriteStartObject();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(value, null);
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, propertyValue);
            }
            writer.WriteEndObject();
        }
    }
