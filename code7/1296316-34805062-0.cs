       public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
{
    var mb = request.CreateBufferedCopy(int.MaxValue);
    request = mb.CreateMessage();
    var ms = new MemoryStream();
 
    // Dump message size based on text encoder.
    using (var memWriter = XmlDictionaryWriter.CreateTextWriter(ms))
    {
        mb.CreateMessage().WriteMessage(memWriter);
        memWriter.Flush();
        Console.WriteLine("Message size using text encoder {0}", ms.Position);
    }
    ms = new MemoryStream(); 
    if (gzipEncoding != null)
    {// GZip Special case
        var encoder = gzipEncoding.CreateMessageEncoderFactory().CreateSessionEncoder();
        encoder.WriteMessage(mb.CreateMessage(), ms);
        Console.WriteLine("GZip encoded size {0}", ms.Position);
        return null;
    }
    // just wrap the message – and wrapper will do the trick.
    request = new WrappingMessage(request);
    return null;
