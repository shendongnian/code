    public class ListJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var theFoo = new Foo();
    
            dynamic dynamicObject = serializer.Deserialize(reader);
    
            if (dynamicObject.any.GetType() == typeof (JArray))
            {
                var items = new List<object>();
    
                foreach (var item in dynamicObject.any)
                {
                    items.Add(item);
                }
    
                theFoo.Any = items;
            }
            else
            {
                theFoo.Any = dynamicObject.any;
            }
    
            return theFoo;
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Foo);
        }
    
        public override bool CanRead
        {
            get { return true; }
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    }
