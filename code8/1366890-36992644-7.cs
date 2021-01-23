    class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Root));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Root root = new Root();
            root.Author = (string)obj["Author"];
            root.Version = (string)obj["Version"];
            root.Children = ((Type1)DeserializeTypeX(obj, serializer)).Children;
            return root;
        }
        private object DeserializeTypeX(JObject obj, JsonSerializer serializer)
        {
            JProperty prop = obj.Properties().Where(p => p.Name.StartsWith("data.")).First();
            JObject child = (JObject)prop.Value;
            if (prop.Name == "data.Type1")
            {
                List<object> children = new List<object>();
                foreach (JObject jo in child["Children"].Children<JObject>())
                {
                    children.Add(DeserializeTypeX(jo, serializer));
                }
                return new Type1 { Children = children };
            }
            else if (prop.Name == "data.Type2")
            {
                return child.ToObject<Type2>(serializer);
            }
            else if (prop.Name == "data.Type3")
            {
                return child.ToObject<Type3>(serializer);
            }
            throw new JsonSerializationException("Unrecognized type: " + prop.Name);
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
