    public class PagedDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(PagedData<>);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            string dataPropertyName = (string)type.GetProperty("DataPropertyName").GetValue(value);
            if (string.IsNullOrEmpty(dataPropertyName)) 
            {
            	dataPropertyName = "Data";
            }
            JObject jo = new JObject();
            jo.Add(dataPropertyName, JArray.FromObject(type.GetProperty("Data").GetValue(value)));
            foreach (PropertyInfo prop in type.GetProperties().Where(p => !p.Name.StartsWith("Data")))
            {
                jo.Add(prop.Name, new JValue(prop.GetValue(value)));
            }
            jo.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
