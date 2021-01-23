        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Wrapper wrapper = (Wrapper)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Instance");
            serializer.Serialize(writer, wrapper.Instance, typeof(object));
            writer.WriteEndObject();
        }
