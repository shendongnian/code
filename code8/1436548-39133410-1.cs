    public class ItemJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Item[,]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var x = jObject.Value<int>("x");
            var y = jObject.Value<int>("y");
            var items = jObject.GetValue("information").ToObject<IEnumerable<Item>>();
            var itemsArray = new Item[x, y];
            foreach (var item in items)
            {
                itemsArray[item.X, item.Y] = item;
            }
            return itemsArray;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
