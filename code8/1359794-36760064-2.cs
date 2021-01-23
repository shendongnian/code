    public class PersonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Person);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var array = JArray.Load(reader);
            var person = (existingValue as Person ?? new Person());
            person.First = (string)array.ElementAtOrDefault(0);
            person.Last = (string)array.ElementAtOrDefault(1);
            person.Age = (string)array.ElementAtOrDefault(2);
            return person;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var person = (Person)value;
            serializer.Serialize(writer, new[] { person.First, person.Last, person.Age });
        }
    }
