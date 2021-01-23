    class TwoDepthJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jo = JObject.FromObject(value);
            foreach (var property in jo)
            {
                foreach (var parameter in property.Value)
                {
                    var paramVal = parameter.First;
                    if (paramVal.Type == JTokenType.Array || paramVal.Type == JTokenType.Object)
                    {
                        paramVal.Replace(JsonConvert.SerializeObject(paramVal.ToObject<object>()));
                    }
                }
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JToken.ReadFrom(reader).ToObject(objectType);
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
