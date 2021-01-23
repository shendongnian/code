    public class BCJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var currentType = (existingValue as System.Collections.ObjectModel.ObservableCollection<A>);
            currentType.Clear();
            var des = serializer.Deserialize<IList<B>>(reader);
            foreach (var toAdd in des)
            {
                currentType.Add(toAdd);
            }
            return currentType;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
