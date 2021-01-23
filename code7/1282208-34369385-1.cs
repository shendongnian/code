    class XmlHierarchicalTextBuilder
    {
        private XmlDocument xmlDoc;
        private string hierarchicalText;
        private int indentlevel = 0;
        private const string NEW_LINE = "\n";
        private const string TAB = "\t";
        private const string PIPE = "|";
        private const string SPACE = " ";
        public XmlHierarchicalTextBuilder (string xml)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml); 
        }
        public string Build()
        {
            Build(xmlDoc.DocumentElement);
            return hierarchicalText;
        }
        private void Build(XmlElement xmlElement) 
        {            
            if (xmlElement.HasChildNodes)
            {
                HandleXmlElementName(xmlElement);
                foreach (XmlNode item in xmlElement.ChildNodes)	 
                {
                    indentlevel++;
                    if (item.NodeType == XmlNodeType.Text)
                    {
                        HandleXmlElementInnerText(xmlElement);                      
                    }
                    else if (item.NodeType == XmlNodeType.Element)
                    {
                        Build((XmlElement)item);
                    }
                    //add more conditions based on different xml node types in future, if u want
                    indentlevel--;
                }
               
            }           
        }
        private void HandleXmlElementInnerText(XmlElement xmlElement)
        {
            addIndent();
            hierarchicalText +=  PIPE + SPACE + xmlElement.InnerText.Trim();
            addNewLine(); 
        }
        private void HandleXmlElementName(XmlElement xmlElement)
        {
            addIndent();
            hierarchicalText += xmlElement.Name;
            addNewLine();
        }
        private void addIndent()
        {
            for (int i = 0; i < indentlevel; i++)
            {
                hierarchicalText += TAB;
            }
        }
        private void addNewLine()
        {
            hierarchicalText += NEW_LINE;
        }
    }
