    public class NestedModel
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Custom { get; set; }
        public List<NestedModel> Children { get; set; }
    }
    public class NestedModelJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var nestedModel = value as NestedModel;
            nestedModel.Custom = "Modified by Json Converter";
            JObject jo = new JObject();
            Type type = nestedModel.GetType();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(nestedModel, null);
                    if (propVal != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            // Create target object based on JObject
            NestedModel target = new NestedModel();
            // Populate the object properties
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, jObject);
            using (JsonTextReader newReader = new JsonTextReader(new StringReader(writer.ToString())))
            {
                newReader.Culture = reader.Culture;
                newReader.DateParseHandling = reader.DateParseHandling;
                newReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
                newReader.FloatParseHandling = reader.FloatParseHandling;
                serializer.Populate(newReader, target);
            }
            return target;
        }
        public override bool CanRead { get { return true; } }
        public override bool CanWrite { get { return true; } }
        public override bool CanConvert(Type objectType) 
        { 
            return typeof(NestedModel).IsAssignableFrom(objectType); 
        }
    }
