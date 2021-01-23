    public class ISerializableConverter<T> : JsonConverter where T : ISerializable
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var oldTypeNameHandling = serializer.TypeNameHandling;
            var oldAssemblyFormat = serializer.TypeNameAssemblyFormat;
            try
            {
                if (serializer.TypeNameHandling == TypeNameHandling.None)
                    serializer.TypeNameHandling = TypeNameHandling.Auto;
                else if (serializer.TypeNameHandling == TypeNameHandling.Arrays)
                    serializer.TypeNameHandling = TypeNameHandling.All;
                var data = serializer.Deserialize<SerializableData>(reader);
                var type = data.ObjectType;
                var info = new SerializationInfo(type, new FormatterConverter());
                foreach (var item in data.Values)
                    info.AddValue(item.Key, item.Value.ObjectValue, item.Value.ObjectType);
                var value = Activator.CreateInstance(type, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { info, serializer.Context }, serializer.Culture);
                if (value is IObjectReference)
                    value = ((IObjectReference)value).GetRealObject(serializer.Context);
                return value;
            }
            finally
            {
                serializer.TypeNameHandling = oldTypeNameHandling;
                serializer.TypeNameAssemblyFormat = oldAssemblyFormat;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var oldTypeNameHandling = serializer.TypeNameHandling;
            var oldAssemblyFormat = serializer.TypeNameAssemblyFormat;
            try
            {
                var serializable = (ISerializable)value;
                var context = serializer.Context;
                var info = new SerializationInfo(value.GetType(), new FormatterConverter());
                serializable.GetObjectData(info, context);
                var data = SerializableData.CreateData(info, value.GetType());
                if (serializer.TypeNameHandling == TypeNameHandling.None)
                    serializer.TypeNameHandling = TypeNameHandling.Auto;
                else if (serializer.TypeNameHandling == TypeNameHandling.Arrays)
                    serializer.TypeNameHandling = TypeNameHandling.All;
                // The following seems to be required by https://github.com/JamesNK/Newtonsoft.Json/issues/787
                serializer.TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full;
                serializer.Serialize(writer, data, typeof(SerializableData));
            }
            finally
            {
                serializer.TypeNameHandling = oldTypeNameHandling;
                serializer.TypeNameAssemblyFormat = oldAssemblyFormat;
            }
        }
    }
    abstract class SerializableValue
    {
        [JsonIgnore]
        public abstract object ObjectValue { get; }
        [JsonIgnore]
        public abstract Type ObjectType { get; }
        public static SerializableValue CreateValue(SerializationEntry entry)
        {
            return CreateValue(entry.ObjectType, entry.Value);
        }
        public static SerializableValue CreateValue(Type type, object value)
        {
            if (value == null)
            {
                if (type == null)
                    throw new ArgumentException("type and value are both null");
                return (SerializableValue)Activator.CreateInstance(typeof(SerializableValue<>).MakeGenericType(type));
            }
            else
            {
                type = value.GetType(); // Use most derived type
                return (SerializableValue)Activator.CreateInstance(typeof(SerializableValue<>).MakeGenericType(type), value);
            }
        }
    }
    sealed class SerializableValue<T> : SerializableValue
    {
        public SerializableValue() : base() { }
        public SerializableValue(T value)
            : base()
        {
            this.Value = value;
        }
        public override object ObjectValue { get { return Value; } }
        public override Type ObjectType { get { return typeof(T); } }
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public T Value { get; private set; }
    }
    abstract class SerializableData
    {
        public SerializableData()
        {
            this.Values = new Dictionary<string, SerializableValue>();
        }
        public SerializableData(IEnumerable<SerializationEntry> values)
        {
            this.Values = values.ToDictionary(v => v.Name, v => SerializableValue.CreateValue(v));
        }
        [JsonProperty("values", ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Dictionary<string, SerializableValue> Values { get; private set; }
        [JsonIgnore]
        public abstract Type ObjectType { get; }
        public static SerializableData CreateData(SerializationInfo info, Type initialType)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            var type = info.GetSavedType(initialType);
            if (type == null)
                throw new InvalidOperationException("type == null");
            return (SerializableData)Activator.CreateInstance(typeof(SerializableData<>).MakeGenericType(type), info.AsEnumerable());
        }
    }
    sealed class SerializableData<T> : SerializableData
    {
        public SerializableData() : base() { }
        public SerializableData(IEnumerable<SerializationEntry> values) : base(values) { }
        public override Type ObjectType { get { return typeof(T); } }
    }
    public static class SerializationInfoExtensions
    {
        public static IEnumerable<SerializationEntry> AsEnumerable(this SerializationInfo info)
        {
            if (info == null)
                throw new NullReferenceException();
            var enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
        public static Type GetSavedType(this SerializationInfo info, Type initialType)
        {
            if (initialType != null)
            {
                if (info.FullTypeName == initialType.FullName
                    && info.AssemblyName == initialType.Module.Assembly.FullName)
                    return initialType;
            }
            var assembly = Assembly.Load(info.AssemblyName);
            if (assembly != null)
            {
                var type = assembly.GetType(info.FullTypeName);
                if (type != null)
                    return type;
            }
            return initialType;
        }
    }
