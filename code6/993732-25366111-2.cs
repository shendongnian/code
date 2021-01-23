    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!(objectType.IsGenericType)) return null;
            var deserializedList = (IList)Activator.CreateInstance(objectType);
            var jArray = JArray.Load(reader);
            var underlyingType = objectType.GetGenericArguments().Single();
            var properties = underlyingType.GetProperties();
            var values = jArray.Skip(1);
            foreach (JArray value in values)
            {
                var obj = Activator.CreateInstance(underlyingType);
                for (var i = 0; i < properties.Length; i++)
                {
                    obj.GetType().GetProperty(properties[i].Name).SetValue(obj, Convert.ChangeType(value[i], properties[i].PropertyType));
                }
                deserializedList.Add(obj);
            }
            return deserializedList;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (!(value.GetType().IsGenericType) || !(value is IList)) return;
            var val = value as IList;
            PropertyInfo[] properties = val.GetType().GetGenericArguments().Single().GetProperties();
            writer.WriteStartArray();
            writer.WriteStartArray();
            foreach (var p in properties)
                writer.WriteValue(p.Name);
            writer.WriteEndArray();
            foreach (var v in val)
            {
                writer.WriteStartArray();
                foreach (var p in properties)
                    writer.WriteValue(v.GetType().GetProperty(p.Name).GetValue(v));
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
    }
