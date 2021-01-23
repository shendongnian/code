    public class GenreConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Genre);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JObject.Load(reader).ToObject<Genre>();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var genre = value as Genre;
            writer.WriteValue(genre.id);
        }
    }
