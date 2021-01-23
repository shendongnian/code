    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                System.IO.File.WriteAllText("c:\\temp\\AfterReceiveReply" + reply.GetHashCode() + ".txt", reply.ToString());
    
                // Read 
                XmlDocument doc = new XmlDocument();
                MemoryStream ms = new MemoryStream();
                XmlWriter writer = XmlWriter.Create(ms);
                reply.WriteMessage(writer);
                writer.Flush();
                ms.Position = 0;
                doc.Load(ms);
    
                // Change 
                ChangeMessageToPBSNamespace(doc);
    
                // Write the new reply 
                ms.SetLength(0);
                writer = XmlWriter.Create(ms);
                doc.WriteTo(writer);
                writer.Flush();
                ms.Position = 0;
                XmlReader reader = XmlReader.Create(ms);
                reply = System.ServiceModel.Channels.Message.CreateMessage(reader, int.MaxValue, reply.Version);
            }
    
            void ChangeMessageToPBSNamespace(XmlDocument doc)
            {
                string xml = doc.OuterXml;
                xml = xml.Replace("http://derpco.com/Namespace", "http://derpco.com/OurNamespace");
                doc.LoadXml(xml);
            }
