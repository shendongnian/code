    public class MessageDateFixer : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            return null;
        }
    
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            XmlDocument document = new XmlDocument();
            MemoryStream memoryStream = new MemoryStream();
            XmlWriter xmlWriter = XmlWriter.Create(memoryStream);
            reply.WriteMessage(xmlWriter);
            xmlWriter.Flush();
            memoryStream.Position = 0;
            document.Load(memoryStream);
    
            FixMessage(document);
    
            memoryStream.SetLength(0);
            xmlWriter = XmlWriter.Create(memoryStream);
            document.WriteTo(xmlWriter);
            xmlWriter.Flush();
            memoryStream.Position = 0;
            XmlReader xmlReader = XmlReader.Create(memoryStream);
            reply = Message.CreateMessage(xmlReader, int.MaxValue, reply.Version);
        }
    
        private static void FixMessage(XmlDocument document)
        {
            FixAllNodes(document.ChildNodes);
        }
    
        private static void FixAllNodes(XmlNodeList list)
        {
            foreach (XmlNode node in list)
            {
                FixNode(node);
            }
        }
    
        private static void FixNode(XmlNode node)
        {
            if (node.Attributes != null &&
                node.Attributes["xsi:type"] != null)
            {
                if (node.Attributes["xsi:type"].Value == "xsd:date")
                {
                    node.Attributes["xsi:type"].Value = "xsd:dateTime";
                    node.InnerXml = node.InnerXml.Replace(" ", "T");
                }
            }
    
            FixAllNodes(node.ChildNodes);
        }
    }
