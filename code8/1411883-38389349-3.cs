    public static class XmlSerializerFactory
    {
        static readonly Dictionary<Tuple<Type, string, string>, XmlSerializer> table;
        static readonly object padlock;
        static XmlSerializerFactory()
        {
            table = new Dictionary<Tuple<Type, string, string>, XmlSerializer>();
            padlock = new object();
        }
        public static XmlSerializer Create(Type serializedType, string rootName, string rootNamespace)
        {
            if (serializedType == null)
                throw new ArgumentNullException();
            if (rootName == null && rootNamespace == null)
                return new XmlSerializer(serializedType);
            lock (padlock)
            {
                var key = Tuple.Create(serializedType, rootName, rootNamespace);
                XmlSerializer serializer;
                if (!table.TryGetValue(key, out serializer))
                {
                    var attr = (string.IsNullOrEmpty(rootName) ? new XmlRootAttribute() { Namespace = rootNamespace } : new XmlRootAttribute(rootName) { Namespace = rootNamespace });
                    serializer = table[key] = new XmlSerializer(serializedType, attr);
                }
                return serializer;
            }
        }
    }
