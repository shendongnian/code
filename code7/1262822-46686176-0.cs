        public readonly Dictionary<string, int> XmlValues = new Dictionary<string, int>();
        public void Analyze(XmlDocument xml)
        {
            RecurseXmlDocument(xml.LastChild);
        }
        void RecurseXmlDocument(XmlNode root)
        {
            switch (root.NodeType)
            {
                case XmlNodeType.Element:
                    if (root.HasChildNodes)
                        RecurseXmlDocument(root.FirstChild);
                    if (root.NextSibling != null)
                        RecurseXmlDocument(root.NextSibling);
                    break;
                case XmlNodeType.Text:
                    DictionayHelper.AddValue(XmlValues, root.Value);
                    break;
            }
        }
