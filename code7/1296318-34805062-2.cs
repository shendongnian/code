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
    }
  
    public class WrappingMessage : Message
    {
      Message innerMsg;  
      MessageBuffer msgBuffer;
  
      public WrappingMessage(Message inner)
      {
        this.innerMsg = inner; 
        msgBuffer = innerMsg.CreateBufferedCopy(int.MaxValue); 
        innerMsg = msgBuffer.CreateMessage();
      }
  
      public override MessageHeaders Headers
      {
        get { return innerMsg.Headers; }
      }
  
      protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
      {
        innerMsg.WriteBodyContents(writer);
      }
  
      public override MessageProperties Properties
      {
        get { return innerMsg.Properties; }
      }
  
      public override MessageVersion Version
      {
        get { return innerMsg.Version; }
      }
  
      protected override void OnWriteMessage(XmlDictionaryWriter writer)
      {
        // write message to the actual stream using encoder..
 
        base.OnWriteMessage(writer); 
        writer.Flush();
 
        // write message to MemoryStream (using encoder) to get it’s size.
        var copy = msgBuffer.CreateMessage();
        DumpEncoderSize(writer, copy);
      }
  
      private static void DumpEncoderSize(System.Xml.XmlDictionaryWriter writer, Message copy)
      {
        var ms = new MemoryStream(); 
        string configuredEncoder = string.Empty; 
        if (writer is IXmlTextWriterInitializer)
        {
            var w = (IXmlTextWriterInitializer)writer; 
            w.SetOutput(ms, Encoding.UTF8, true); 
            configuredEncoder = "Text";
        }
        else if (writer is IXmlMtomWriterInitializer)
        {
          var w = (IXmlMtomWriterInitializer)writer;
          w.SetOutput(ms, Encoding.UTF8, int.MaxValue, "", null, null, true, false);
          configuredEncoder = "MTOM";
        }
        else if (writer is IXmlBinaryWriterInitializer)
        {
          var w = (IXmlBinaryWriterInitializer)writer;
          w.SetOutput(ms, null, null, false);
          configuredEncoder = "Binary";
        }
 
        copy.WriteMessage(writer);
        writer.Flush();
        var size = ms.Position;
        Console.WriteLine("Message size using configured ({1}) encoder {0}",  size,configuredEncoder);
      }
    }
