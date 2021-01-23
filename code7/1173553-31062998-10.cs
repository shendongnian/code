        public static IEnumerable<XElement> StreamNamedElements(XmlReader reader, IEnumerable<XName> names)
        {
            var nameSet = new HashSet<XName>(names);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && nameSet.Contains(XName.Get(reader.LocalName, reader.NamespaceURI)))
                {
                    XElement el = XNode.ReadFrom(reader) as XElement;
                    if (el != null)
                        yield return el;
                }
            }
        }
