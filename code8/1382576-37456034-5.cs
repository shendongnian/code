        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        var key = reader.Name;
                        var value = reader.ReadElementContentAsString();
                        attributes.Add(key, value);
                        break;
                    default:
                        // Comment, for instance.
                        reader.Read();
                        break;
                }
            }
            // Consume the EndElement
            reader.Read();
        }
