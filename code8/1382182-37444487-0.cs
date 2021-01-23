    public static class XmlExtensions
    {
        public static T Deserialize<T>(this XContainer element, XmlSerializer serializer = null)
        {
            using (var reader = element.CreateReader())
            {
                object result = (serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
                if (result is T)
                    return (T)result;
            }
            return default(T);
        }
        public static XElement SerializeToXElement<T>(this T obj, XmlSerializer serializer = null)
        {
            var doc = new XDocument();
            using (var writer = doc.CreateWriter())
                (serializer ?? new XmlSerializer(obj.GetType())).Serialize(writer, obj);
            var element = doc.Root;
            if (element != null)
                element.Remove();
            return element;
        }
        public static XName ContainerElementName { get { return (XName)"Object"; } }
        public static XName ContainerAttributeName { get { return (XName)"Name"; } }
        public static XElement SetItem<T>(this XDocument doc, string attributeValue, T obj)
        {
            return doc.SetItem(ContainerElementName, ContainerAttributeName, attributeValue, obj);
        }
        static XElement SetItem<T>(this XDocument doc, XName containerElementName, XName containerAttributeName, string attributeValue, T obj)
        {
            if (doc == null || containerElementName == null || containerAttributeName == null || attributeValue == null)
                throw new ArgumentNullException();
            if (doc.Root == null)
                throw new ArgumentException("doc.Root == null");
            var container = doc.Root.Elements(containerElementName).Where(e => (string)e.Attribute(containerAttributeName) == attributeValue).SingleOrDefault();
            if (container == null)
            {
                container = new XElement(containerElementName, new XAttribute(containerAttributeName, attributeValue));
                doc.Root.Add(container);
            }
            else
            {
                // Remove old content.
                container.RemoveNodes();
            }
            var element = obj.SerializeToXElement();
            container.Add(element);
            return element;
        }
        public static T GetItem<T>(this XDocument doc, string attributeValue)
        {
            return doc.GetItem<T>(ContainerElementName, ContainerAttributeName, attributeValue);
        }
        static T GetItem<T>(this XDocument doc, XName containerElementName, XName containerAttributeName, string attributeValue)
        {
            if (doc == null || containerElementName == null || containerAttributeName == null || attributeValue == null)
                throw new ArgumentNullException();
            if (doc.Root == null)
                throw new ArgumentException("doc.Root == null");
            var container = doc.Root.Elements(containerElementName).Where(e => (string)e.Attribute(containerAttributeName) == attributeValue).SingleOrDefault();
            if (container == null)
                return default(T);
            var element = container.Elements().SingleOrDefault();
            if (element == null)
                return default(T);
            return element.Deserialize<T>();
        }
        public static XDocument CreateDefaultXDocument()
        {
            var xml = @"<StoredObjects></StoredObjects>";
            return XDocument.Parse(xml);
        }
    }
