        public void ReadXml(XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            // jump to <parameters>
            reader.Read();
            if (wasEmpty)
                return;
            // read until we reach the last element
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)
            {
                // jump to <item>
                reader.MoveToContent();
                // jump to key attribute and read
                string key = reader.GetAttribute("key");
                // jump to value attribute and read
                string value = reader.GetAttribute("value");
                // add item to the dictionary
                this.Add(key, value);
                // jump to next <item>
                reader.ReadStartElement("item");
                reader.MoveToContent(); // workaround to trigger node type
            }
            // Consume the </Parameters> node as required by the documentation
            // https://msdn.microsoft.com/en-us/library/system.xml.serialization.ixmlserializable.readxml%28v=vs.110%29.aspx
            // Unlike the WriteXml method, the framework does not handle the wrapper element automatically. Your implementation must do so. 
            reader.Read();
        }
