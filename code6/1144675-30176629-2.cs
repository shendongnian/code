    public class MyModelJsonConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return true; }
        }
        
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MyModel);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
    		if (objectType != typeof(MyModel))
			{
				throw new ArgumentException("objectType");
			}
			
			switch (reader.TokenType)
			{
				case JsonToken.Null:
				{
					return null;
				}
				case JsonToken.StartObject:
				{
					reader.Read();
					break;
				}
				default:
				{
					throw new JsonSerializationException();
				}
			}
			
			var result = new MyModel();
			bool inDetails = false;
			
			while (reader.TokenType == JsonToken.PropertyName)
			{
				string propertyName = reader.Value.ToString();
				if (string.Equals("name", propertyName, StringComparison.OrdinalIgnoreCase))
				{
					reader.Read();
					result.Name = serializer.Deserialize<string>(reader);
				}
				else if (string.Equals("size", propertyName, StringComparison.OrdinalIgnoreCase))
				{
					if (!inDetails)
					{
						throw new JsonSerializationException();
					}
					
					reader.Read();
					result.Size = serializer.Deserialize<string[]>(reader);
				}
				else if (string.Equals("weight", propertyName, StringComparison.OrdinalIgnoreCase))
				{
					if (!inDetails)
					{
						throw new JsonSerializationException();
					}
					
					reader.Read();
					result.Weight = serializer.Deserialize<string>(reader);
				}
				else if (string.Equals("details", propertyName, StringComparison.OrdinalIgnoreCase))
				{
					reader.Read();
					
					if (reader.TokenType != JsonToken.StartObject)
					{
						throw new JsonSerializationException();
					}
					
					inDetails = true;
				}
				else
				{
					reader.Skip();
				}
				
				reader.Read();
			}
			if (inDetails)
			{
				if (reader.TokenType != JsonToken.EndObject)
				{
					throw new JsonSerializationException();
				}
				
				reader.Read();
			}
			
			return result;
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            
            var model = value as MyModel;
            if (model == null) throw new JsonSerializationException();
            
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue(model.Name);
            writer.WritePropertyName("details");
            writer.WriteStartObject();
            writer.WritePropertyName("size");
            serializer.Serialize(writer, model.Size);
            writer.WritePropertyName("weight");
            writer.WriteValue(model.Weight);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }
    }
    
    [JsonConverter(typeof(MyModelJsonConverter))]
    public class MyModel
    {
        public string Name { get; set; }
        public string[] Size { get; set; }
        public string Weight { get; set; }
    }
