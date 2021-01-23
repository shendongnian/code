        public static IEnumerable<Dictionary<XName, XElement>> StreamNamedElements(XmlReader reader, IEnumerable<XName> names)
        {
            // Note that, for performance and memory reasons, the dictionary is RECYCLED and REUSED on every yield
            Dictionary<XName, XElement> dictionary = new Dictionary<XName, XElement>();
            var nameSet = new HashSet<XName>(names);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && nameSet.Contains(XName.Get(reader.Name, reader.NamespaceURI)))
                {
                    XElement el = XNode.ReadFrom(reader) as XElement;
                    if (el != null)
                    {
                        dictionary[el.Name] = el;
                        yield return dictionary;
                    }
                }
            }
        }
