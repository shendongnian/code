        private static void Serialize<TKey, TValue>(TextWriter writer, IDictionary<TKey, TValue> dictionary)
        {
            var entries = dictionary.Select(pair => new Entry<TKey, TValue>(pair.Key, pair.Value)).ToList();
            var serializer = new XmlSerializer(entries.GetType());
            serializer.Serialize(writer, entries);
        }
        private static void Deserialize<TKey, TValue>(TextReader reader, IDictionary<TKey, TValue> dictionary)
        {
            var serializer = new XmlSerializer(typeof(List<Entry<TKey, TValue>>));
            var list = (List<Entry<TKey, TValue>>)serializer.Deserialize(reader);
            dictionary.Clear();
            foreach (var entry in list)
            {
                dictionary[entry.Key] = entry.Value;
            }
        }
        public class Entry<TKey, TValue>
        {
            public TKey Key;
            public TValue Value;
            public Entry() { }
            public Entry(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
