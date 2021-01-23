    class ResultConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Result);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Result result = new Result();
            result.Success = (bool)obj["success"];
            JProperty prop = obj.Properties().FirstOrDefault(p => p.Name != "success");
            if (prop != null)
            {
                result.classid = prop.Value.ToObject<ClassId>(serializer);
            }
            return result;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
