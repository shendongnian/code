    [System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
    public class XmlWrapCDataAttribute : Attribute
    {
        public XmlWrapCDataAttribute() { this.Namespace = string.Empty;  }
        public XmlWrapCDataAttribute(string name) : this() { this.Name = name; }
        public string Name { get; set; }
        public string Namespace { get; set; }
    }
    public static class XmlWrapCDataHelper
    {
        static Tuple<PropertyInfo, XmlWrapCDataAttribute> [] XmlWrapCDataProperties(Type type)
        {
            return type.GetProperties()
                .Where(p => p.GetGetMethod() != null && p.GetSetMethod() != null)
                .Select(p => Tuple.Create(p, p.GetCustomAttribute<XmlWrapCDataAttribute>()))
                .Where(p => p.Item2 != null)
                .ToArray();
        }
        public static XmlNode[] GetCDataContent(object obj)
        {
            var index = new object[0];
            var properties = XmlWrapCDataProperties(obj.GetType());
            return properties.Select(p => (XmlNode)p.Item1.GetValue(obj, index).GetCData(p.Item2.Name ?? p.Item1.Name, p.Item2.Namespace)).ToArray();
        }
        public static void SetCDataContent(object obj, XmlNode [] nodes)
        {
            if (nodes == null || nodes.Length < 1)
                return;
            var index = new object[0];
            var properties = XmlWrapCDataProperties(obj.GetType()).ToDictionary(p => XName.Get(p.Item2.Name ?? p.Item1.Name, p.Item2.Namespace), p => p);
            var xml = "<Root>" + String.Concat(nodes.Select(c => c.Value)) + "</Root>";
            foreach (var element in XElement.Parse(xml).Elements())
            {
                Tuple<PropertyInfo, XmlWrapCDataAttribute> pair;
                if (properties.TryGetValue(element.Name, out pair))
                {
                    var value = element.Deserialize(pair.Item1.PropertyType, element.Name.LocalName, element.Name.Namespace.NamespaceName);
                    pair.Item1.SetValue(obj, value, index);
                }
            }
        }
    }
    public static class XmlSerializationHelper
    {
        public static XmlCDataSection GetCData(this object obj, string rootName, string rootNamespace)
        {
            return obj == null ? null : new System.Xml.XmlDocument().CreateCDataSection(obj.GetXml(XmlSerializerFactory.Create(obj.GetType(), rootName, rootNamespace)));
        }
        public static XCData GetCData(this object obj, XmlSerializer serializer = null)
        {
            return obj == null ? null : new XCData(obj.GetXml(serializer));
        }
        public static string GetXml(this object obj, XmlSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "  ", OmitXmlDeclaration = true }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    (serializer ?? new XmlSerializer(obj.GetType())).Serialize(xmlWriter, obj, ns);
                return textWriter.ToString();
            }
        }
        public static object Deserialize(this XContainer element, Type type, string rootName = null, string rootNamespace = null)
        {
            return element.Deserialize(type, XmlSerializerFactory.Create(type, rootName, rootNamespace));
        }
        public static object Deserialize(this XContainer element, Type type, XmlSerializer serializer = null)
        {
            using (var reader = element.CreateReader())
            {
                return (serializer ?? new XmlSerializer(type)).Deserialize(reader);
            }
        }
        public static T DeserializeXML<T>(this string xmlString, XmlSerializer serializer = null)
        {
            using (StringReader reader = new StringReader(xmlString))
            {
                return (T)(serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
            }
        }
    }
    public static class XmlSerializerFactory
    {
        readonly static Dictionary<Tuple<Type, string, string>, XmlSerializer> cache;
        readonly static object padlock;
        static XmlSerializerFactory()
        {
            padlock = new object();
            cache = new Dictionary<Tuple<Type, string, string>, XmlSerializer>();
        }
        public static XmlSerializer Create(Type serializedType, string rootName, string rootNamespace)
        {
            if (serializedType == null)
                throw new ArgumentNullException();
            if (rootName == null && rootNamespace == null)
                return new XmlSerializer(serializedType);
            lock (padlock)
            {
                XmlSerializer serializer;
                var key = Tuple.Create(serializedType, rootName, rootNamespace);
                if (!cache.TryGetValue(key, out serializer))
                    cache[key] = serializer = new XmlSerializer(serializedType, new XmlRootAttribute { ElementName = rootName, Namespace = rootNamespace });
                return serializer;
            }
        }
    }
