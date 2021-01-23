     public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
     {
         // Loggin incoming message
         log.WriteLine("Incoming message :");
    
         MessageEncoder encoder = OperationContext.Current.IncomingMessageProperties.Encoder;
         string contentType = encoder.ContentType;
         Match characterSetMatch = re.Match(contentType);
    
         if (!characterSetMatch.Success)
         {
             log.WriteLine("Failed to extract character set from request content type: " + contentType);
         }
         else
         {
             try
             {    
                 Type bufferedMessageType = typeof(Message).Assembly.GetType("System.ServiceModel.Channels.BufferedMessage");
                 Type bufferedMessageData = typeof(Message).Assembly.GetType("System.ServiceModel.Channels.BufferedMessageData");
    
                 string characterSet = characterSetMatch.Groups[0].Value;
    
                 object messageData = bufferedMessageType.InvokeMember("MessageData",
                               BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty,
                               null, request, null);
    
                 object buffer = bufferedMessageData.InvokeMember("Buffer",
                                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty,
                                            null, messageData, null);
    
    
                 ArraySegment<byte> arrayBuffer = (ArraySegment<byte>)buffer;
                 Encoding encoding = Encoding.GetEncoding(characterSet);
    
                 string requestMessage = encoding.GetString(arrayBuffer.Array, arrayBuffer.Offset, arrayBuffer.Count);
    
                 log.WriteLine(requestMessage);
             }
             catch(Exception e)
             {
                 log.WriteLine("Error in decoding incoming message");
                 log.WriteException(e);
             }
    
         }
    
         return null;
     }
