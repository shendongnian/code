        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JContainer lJContainer = default(JContainer);
            if (reader.TokenType == JsonToken.StartObject)
            {
                lJContainer = JObject.Load(reader);
                existingValue = Convert.ChangeType(existingValue, objectType);
                existingValue = Activator.CreateInstance(objectType);
                serializer.Populate(lJContainer.CreateReader(), existingValue);
            }
            return existingValue;
        }
