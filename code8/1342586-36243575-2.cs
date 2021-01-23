    public class CustomCoverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                PriceHistoryRecordModel obj = value as PriceHistoryRecordModel;
                JToken t = JToken.FromObject(new double[] { obj.Date.Ticks, obj.Value });
                t.WriteTo(writer);
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override bool CanConvert(Type objectType)
            {
                return typeof(PriceHistoryRecordModel).IsAssignableFrom(objectType);
            }
        }
