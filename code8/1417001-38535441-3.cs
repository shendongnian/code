    public static class XmlTypeExtensions
    {
        public static T DeserializeNestedElement<T>(string xmlString)
        {
            var mySerializer = new XmlSerializer(typeof(T));
            var typeName = typeof(T).XmlTypeName();
            var typeNamespace = typeof(T).XmlTypeNamespace();
            using (var myXmlReader = XmlReader.Create(new StringReader(xmlString)))
            {
                while (myXmlReader.Read())
                    if (myXmlReader.NodeType == XmlNodeType.Element && myXmlReader.Name == typeName && myXmlReader.NamespaceURI == typeNamespace)
                    {
                        return (T)mySerializer.Deserialize(myXmlReader);
                    }
                return default(T);
            }
        }
        public static string XmlTypeName(this Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.TypeName))
                return xmlType.TypeName;
            return type.Name;
        }
        public static string XmlTypeNamespace(this Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.Namespace))
                return xmlType.Namespace;
            return string.Empty;
        }
    }
