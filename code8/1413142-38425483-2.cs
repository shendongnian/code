    public static class XmlReaderExtensions
    {
        public static IEnumerable<XmlReader> ReadSubtrees(this XmlReader reader, string localName)
        {
            while (reader.ReadToFollowing(localName))
            {
                using (var subReader = reader.ReadSubtree())
                    yield return subReader;
            }
        }
    }
