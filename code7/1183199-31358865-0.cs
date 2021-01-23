    class Program
    {
        static void Main(string[] args)
        {
            var document = new XmlDocument();
            document.Load("Sample.xml");
    
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
            nsmgr.AddNamespace("ns", "urn:Test");
    
            var intervalNodes = document.SelectNodes("//ns:Interval", nsmgr);
            foreach(XmlNode node in intervalNodes)
            {
                var quantityNode = node.SelectSingleNode("./ns:Qty", nsmgr);
                quantityNode.Attributes["v"].Value = "New Value";
            }
        }
    }
