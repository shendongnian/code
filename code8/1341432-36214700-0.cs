    public class OrgChartConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Node<Person>));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Node<Person> node = (Node<Person>)value;
            JObject obj = new JObject();
            obj.Add("Name", node.Value.Name);
            obj.Add("Subordinates", JArray.FromObject(node.Children, serializer));
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
