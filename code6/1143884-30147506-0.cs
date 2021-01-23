     public class Product
        {
            public string product { get; set; }
            [JsonConverter(typeof(MyConverter ))]
            public decimal[] price { get; set; }
        }
     public class MyConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return false;
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if(reader.TokenType == JsonToken.StartArray)
                {
                    return serializer.Deserialize(reader, objectType);
                }
                return new decimal[] { decimal.Parse(reader.Value.ToString()) };              
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
