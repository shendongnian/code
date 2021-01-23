     public class MyJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType.Equals(typeof(String));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                //no need, we are setting canRed to false. 
                return null;
            }
            public override bool CanRead
            {
                get
                {
                    return false;
                }
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (((String)value).StartsWith("{")){ //more accuracy required here ofc. 
                    //Take that as a json String
                    writer.WriteRawValue((String)value);
                }
                else
                {
                    writer.WriteValue(value);
                }
            }
        }
