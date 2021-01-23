    private void ModifyReceivedRequest(ref Message message)
        {
            MemoryStream ms = new MemoryStream();
            Encoding encoding = Encoding.UTF8;
            XmlWriterSettings writerSettings = new XmlWriterSettings { Encoding = encoding };
            writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
            writerSettings.Indent = true;
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create(ms, writerSettings));
            message.WriteBodyContents(writer);
            writer.Flush();
            ms.Position = 0;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(ms);
            ms.Flush();
            ms = new MemoryStream();
           // XML stuff
            GC.Collect();
            xDoc.Save(ms);
            ms.Position = 0;
            XmlReader bodyReader = XmlReader.Create(ms);
            Message originalMessage = message;
            message = Message.CreateMessage(originalMessage.Version, null, bodyReader);
            message.Headers.CopyHeadersFrom(originalMessage);
        }
