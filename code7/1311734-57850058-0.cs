    var settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new OrgChartConverter() },
                        Formatting = Formatting.Indented
                    };
                    string json = JsonConvert.SerializeObject(tree, settings);
    public class OrgChartConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Node<T>).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Node<T> node = (Node<T>)value;
            JObject obj = new JObject();
            obj.Add("Name", node.Value.Name);
            obj.Add("Children", JArray.FromObject(node.Children, serializer));
            obj.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
