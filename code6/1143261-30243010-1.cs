    System.ServiceModel.Channels.Message message; // the inbound SOAP
    var buffer = message.CreateBufferedCopy(MaxMessageSize);
    var message = buffer.CreateMessage();
    using (MemoryStream stream = new MemoryStream())
    using (XmlWriter writer = XmlWriter.Create(stream))
    {
        message.WriteMessage(writer);
        writer.Flush();
        stream.Position = 0;
        using (XmlReader reader = XmlReader.Create(stream))
        {
            // business logic goes here
        }
    }
