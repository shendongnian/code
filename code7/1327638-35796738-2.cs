    class DuplicateJsonConverter : JsonConverter
    {
        public override bool CanWrite { get { return false; } }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var paths = new HashSet<string>();
            existingValue = existingValue ?? Activator.CreateInstance(objectType, true);
            var backup = new StringWriter();
            using (var writer = new JsonTextWriter(backup))
                do
                {
                    writer.WriteToken(reader.TokenType, reader.Value);
                    if (reader.TokenType != JsonToken.PropertyName)
                        continue;
                    if (string.IsNullOrEmpty(reader.Path))
                        continue;
                    if (paths.Contains(reader.Path))
                           throw new HttpResponseException(HttpStatusCode.BadRequest); //as 400
                    paths.Add(reader.Path);
                }
                while (reader.Read());
            JsonConvert.PopulateObject(backup.ToString(), existingValue);
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
