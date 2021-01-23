    public class CollectionBaseConverter<TCollection, TItem> : JsonConverter where TCollection : CollectionBase
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(TCollection).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            TCollection collection = (TCollection)(existingValue ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
            var wrapper = new CollectionBaseWrapper<TCollection, TItem>(collection);
            serializer.Populate(reader, wrapper);
            return collection;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = (TCollection)value;
            serializer.Serialize(writer, collection.Cast<TItem>());
        }
    }
    class CollectionBaseWrapper<TCollection, TItem> : ICollection<TItem> where TCollection : CollectionBase
    {
        readonly IList collection;
        public CollectionBaseWrapper(TCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            this.collection = collection;
        }
        public void Add(TItem item)
        {
            collection.Add(item);
        }
        public void Clear()
        {
            collection.Clear();
        }
        public bool Contains(TItem item)
        {
            return collection.Contains(item);
        }
        public void CopyTo(TItem[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count { get { return collection.Count; } }
        public bool IsReadOnly { get { return collection.IsReadOnly; } }
        public bool Remove(TItem item)
        {
            bool found = collection.Contains(item);
            if (found)
                collection.Remove(item);
            return found;
        }
        public IEnumerator<TItem> GetEnumerator()
        {
            return collection.Cast<TItem>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
