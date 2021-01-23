    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.BaseType;
            }
        }
    }
    public class NodeConverter : JsonConverter
    {
        class NodeWrapper<T>
        {
            public T value { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public IEnumerable<Node<T>> children { get; set; }
        }
        static Type GetNodeValueType(Type type)
        {
            return type.BaseTypesAndSelf().Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Node<>)).Select(t => t.GetGenericArguments()[0]).FirstOrDefault();
        }
        public override bool CanConvert(Type objectType)
        {
            return GetNodeValueType(objectType) != null;
        }
        object ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var wrapper = serializer.Deserialize<NodeWrapper<T>>(reader);
            if (wrapper == null)
                return existingValue;
            var node = existingValue as Node<T> ?? new Node<T>(wrapper.value);
            node.Value = wrapper.value;
            if (wrapper.children != null)
                foreach (var child in wrapper.children)
                    node.Add(child);
            return node;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var method = GetType().GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(new[] { GetNodeValueType(objectType) });
            return genericMethod.Invoke(this, new object[] { reader, objectType, existingValue, serializer });
        }
        void WriteJsonGeneric<T>(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var node = (Node<T>)value;
            serializer.Serialize(writer, new NodeWrapper<T> { value = node.Value, children = (node.Children.Any() ? node.Children : null)});
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var method = GetType().GetMethod("WriteJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var genericMethod = method.MakeGenericMethod(new[] { GetNodeValueType(value.GetType()) });
            genericMethod.Invoke(this, new object[] { writer, value, serializer });
        }
    }
