    public class TestResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TestResponse);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            else if (reader.TokenType == JsonToken.StartArray)
            {
                // A valid response.  Populare the Tests array.
                var tests = serializer.Deserialize<Test[]>(reader);
                return new TestResponse { Tests = tests };
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                // An error response.  Populate HasError and Message
                var response = new TestResponse();
                serializer.Populate(reader, response);
                return response;
            }
            else
            {
                throw new JsonSerializationException("Unexpected reader.TokenType: " + reader.TokenType);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var test = (TestResponse)value;
            if (test.HasError && test.Tests != null && test.Tests.Length > 0)
            {
                serializer.Serialize(writer, new { HasError = test.HasError, Message = test.Message, Tests = test.Tests });
            }
            else if (test.HasError || test.Tests == null)
            {
                serializer.Serialize(writer, new { HasError = test.HasError, Message = test.Message });
            }
            else
            {
                serializer.Serialize(writer, test.Tests);
            }
        }
    }
