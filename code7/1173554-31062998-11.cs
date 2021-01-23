        public static IEnumerable<XmlReader> StreamNamedSubtrees(XmlReader reader, IEnumerable<XName> names)
        {
            var nameSet = new HashSet<XName>(names);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && nameSet.Contains(XName.Get(reader.LocalName, reader.NamespaceURI)))
                {
                    var subReader = reader.ReadSubtree();
                    yield return subReader;
                    ((IDisposable)subReader).Dispose(); // Be sure to advance to the end of the subtree if the caller did not.
                }
            }
        }
