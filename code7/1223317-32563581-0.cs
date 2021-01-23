    class DualDateJsonConverter : JsonConverter
    {
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
    
            JObject result = new JObject();
    
            DualDate dd = (DualDate)value;
    
            result.Add("DateOne", JToken.FromObject(dd.DateOne.ToString("MM.dd.yyyy")));
            result.Add("DateTwo", JToken.FromObject(dd.DateTwo));
            result.WriteTo(writer);
        }
    
        // Other JsonConverterMethods
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DualDate);
        }
    
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
     Context.Response.ContentType = "application/json";
     Context.Response.Write(response);
