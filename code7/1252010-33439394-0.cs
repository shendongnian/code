        public void ReadXml(System.Xml.XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            // jump to <parameters>
            reader.Read();
            if (wasEmpty)
                return;
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                // jump to <item>
                reader.MoveToContent();
                
                reader.MoveToAttribute("key");
                string key = reader.GetAttribute("key");
                reader.MoveToAttribute("value");
                string value = reader.GetAttribute("value");
                this.Add(key, value);
                reader.ReadStartElement("item");
                reader.MoveToContent();
            }
        }
