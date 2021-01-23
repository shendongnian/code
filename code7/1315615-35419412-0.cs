        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Wrapper wrapper = (Wrapper)value;
            JObject root = new JObject();
            using (var tokenWriter = new JTokenWriter())
            {
                serializer.Serialize(tokenWriter, wrapper.Instance, typeof(object));
                root.Add("Instance", tokenWriter.Token);                
            }
            root.WriteTo(writer);
        }
