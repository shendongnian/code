    public static class XmlReaderExtensions
    {
        public static IEnumerable<XmlReader> ReadSubtrees(this XmlReader reader, string name)
        {
            while (reader.ReadToFollowing(name))
            {
                using (var subReader = reader.ReadSubtree())
                    yield return subReader;
            }
        }
    }
