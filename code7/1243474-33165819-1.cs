        public void ReadXml(XmlReader reader)
        {
            reader.Read();
            do
            {
                if (!reader.IsEmptyElement)
                {
                    var name = reader.Name;
                    var val = Convert.ToDouble(reader.ReadElementContentAsString());
                    Values.Add(name, val);
                }
                else
                {
                    reader.Skip();
                }
            } while (reader.Name != "week");
            if (reader.NodeType == XmlNodeType.EndElement)
            {
                reader.ReadEndElement();
            }
        }
