    [XmlType("KeyValue"), XmlRoot("KeyValue")]
    public class SerializableKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
    public static class SerializableKeyValuePairExtensions
    {
        public static SerializableKeyValuePair<TKey, TValue> ToSerializablePair<TKey, TValue>(this KeyValuePair<TKey, TValue> pair)
        {
            return new SerializableKeyValuePair<TKey, TValue> { Key = pair.Key, Value = pair.Value };
        }
    }
    [DataContract]
    public class DetailLog
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SubAction { get; set; }
        [DataMember]
        [XmlIgnore]
        public Dictionary<string, string> Fields { get; set; }
        [IgnoreDataMember]
        [XmlArray("Fields")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public SerializableKeyValuePair<string, string>[] FieldsArray
        {
            get
            {
                return Fields == null ? null : Fields.Select(p => p.ToSerializablePair()).ToArray();
            }
            set
            {
                Fields = value == null ? null : value.ToDictionary(p => p.Key, p => p.Value);
            }
        }
        [DataMember]
        public string UserName { get; set; }
    }
