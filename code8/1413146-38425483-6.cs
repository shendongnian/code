    public static partial class XmlReaderExtensions
    {
        public static IEnumerable<string> ReadAllElementContentsAsString(this XmlReader reader, string localName, string namespaceURI)
        {
            while (reader.ReadToFollowing(localName, namespaceURI))
                yield return reader.ReadElementContentAsString();
        }
		
        public static IEnumerable<XmlReader> ReadAllSubtrees(this XmlReader reader, string localName, string namespaceURI)
        {
            while (reader.ReadToFollowing(localName, namespaceURI))
                using (var subReader = reader.ReadSubtree())
                    yield return subReader;
        }
    }
