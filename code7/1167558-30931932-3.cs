    class MyJsonCreationConverter : JsonConverter
    {
        private static readonly ConcurrentDictionary<Type, Func<DirtyPropertiesBase>> ContructorCache = new ConcurrentDictionary<Type, Func<DirtyPropertiesBase>>();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("MyJsonCreationConverter should only be used while deserializing.");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            Func<DirtyPropertiesBase> constructor = ContructorCache.GetOrAdd(objectType, x =>
                (Func<DirtyPropertiesBase>)typeof(DirtyPropertiesBase.Create<>).MakeGenericType(objectType).GetField("New").GetValue(null));
            DirtyPropertiesBase value = constructor();
            serializer.Populate(reader, value);
            return value;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (DirtyPropertiesBase).IsAssignableFrom(objectType);
        }
    }
