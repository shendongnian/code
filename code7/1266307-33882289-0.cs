    public class XMLManager
    {
        private XmlDocument document;
        private XmlNodeList nodeList;
    
        public void OpenFile(string file)
        {
            document = new XmlDocument();
            document.Load(file);
            nodeList = document.SelectNodes(@"Settings/Settings");
        }
    
        public string Get(string attrib)
        {
            for (int i = 0; i < nodeList.Count; i++)
            {
                if (nodeList[i].Attributes[attrib] != null)
                {
                    return nodeList[i].Attributes[attrib].Value;
                }
            }
            return null;
        }
    }
