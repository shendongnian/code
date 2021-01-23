    public class UserNameConverter : JsonConverter
    {
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var username = (UserName)value;
    
            writer.WriteStartObject();
            writer.WritePropertyName("UserName");
            serializer.Serialize(writer, username.ToString());
            writer.WriteEndObject();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Variables to be set along with sensing variables
            string username = null;
            var gotName = false;
    
            // Read the properties
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                {
                    break;
                }
    
                var propertyName = (string)reader.Value;
                if (!reader.Read())
                {
                    continue;
                }
    
                // Set the group
                if (propertyName.Equals("UserName", StringComparison.OrdinalIgnoreCase))
                {
                    username = serializer.Deserialize<string>(reader);
                    gotName = true;
                }
            }
    
            if (!gotName)
            {
                throw new InvalidDataException("A username must be present.");
            }
    
            return new UserName(username);
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserName);
        }
    }
