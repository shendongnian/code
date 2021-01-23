    public static class XObjectExtensions
    {
        public static XmlSerializerNamespaces NoStandardXmlNamespaces()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            return ns;
        }
        public static object Deserialize(this XContainer element, Type type, XmlSerializer serializer)
        {
            using (var reader = element.CreateReader())
            {
                return (serializer ?? new XmlSerializer(type)).Deserialize(reader);
            }
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializerNamespaces ns, XmlSerializer serializer)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj, ns);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
        const string TypeAttributeName = "AssemblyQualifiedName";
        public static T DeserializePolymorphicEntry<T>(this XElement[] arrayValue, XName name)
        {
            var element = arrayValue.Where(e => e.Name == name).FirstOrDefault();
            return element.DeserializePolymorphic<T>(name);
        }
        public static T DeserializePolymorphic<T>(this XElement value, XName name)
        {
            if (value == null)
                return default(T);
            var typeName = (string)value.Attribute(TypeAttributeName);
            if (typeName == null)
                throw new InvalidOperationException(string.Format("Missing AssemblyQualifiedName for \"{0}\"", value.ToString()));
            var type = Type.GetType(typeName, true); // Throw on error
            return (T)value.Deserialize(type, XmlSerializerFactory.Create(type, name));
        }
        public static XElement SerializePolymorphicToXElement<T>(this T obj, XName name)
        {
            if (obj == null)
                return null;
            var element = obj.SerializeToXElement(XObjectExtensions.NoStandardXmlNamespaces(), XmlSerializerFactory.Create(obj.GetType(), name));
            // Remove namespace attributes (they will be added back by the XmlWriter if needed)
            foreach (var attr in element.Attributes().Where(a => a.IsNamespaceDeclaration).ToList())
                attr.Remove();
            element.Add(new XAttribute("AssemblyQualifiedName", obj.GetType().AssemblyQualifiedName));
            return element;
        }
    }
    public static class XmlSerializerFactory
    {
        static readonly object padlock;
        static readonly Dictionary<Tuple<Type, XName>, XmlSerializer> serializers;
        // An explicit static constructor enables fairly lazy initialization.
        static XmlSerializerFactory()
        {
            padlock = new object();
            serializers = new Dictionary<Tuple<Type, XName>, XmlSerializer>();
        }
        /// <summary>
        /// Return a cached XmlSerializer for the given type and root name.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns>a cached XmlSerializer</returns>
        public static XmlSerializer Create(Type type, XName name)
        {
            // According to https://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlserializer%28v=vs.110%29.aspx
            // XmlSerializers created with new XmlSerializer(Type, XmlRootAttribute) must be cached in a hash table 
            // to avoid a severe memory leak & performance hit.
            if (type == null)
                throw new ArgumentNullException();
            if (name == null)
                return new XmlSerializer(type);
            lock (padlock)
            {
                XmlSerializer serializer;
                var key = Tuple.Create(type, name);
                if (!serializers.TryGetValue(key, out serializer))
                    serializers[key] = serializer = new XmlSerializer(type, new XmlRootAttribute { ElementName = name.LocalName, Namespace = name.NamespaceName });
                return serializer;
            }
        }
    }
