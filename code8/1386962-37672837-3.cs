    public override Message ReadMessage(ArraySegment<byte> buffer,
      BufferManager bufferManager, string contentType)
    {
      var content = Encoding.UTF8.GetString(buffer.ToArray());
      var response = innerEncoder.ReadMessage(buffer, bufferManager, contentType);
      response.Properties.Add("RawMessage", content);
      
      // some other staff here..
    }
