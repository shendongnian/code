     public class MyTextMessageEncoder : MessageEncoder
     {
    
            public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
            {
                StreamReader sreader = new StreamReader(stream);
                string msg = sreader.ReadToEnd();
    
                stream.Seek(0, SeekOrigin.Begin);
                XmlReader reader = XmlReader.Create(stream);
                var message = Message.CreateMessage(reader, maxSizeOfHeaders, this.MessageVersion);
                // Here I add my MessageHeader
                var poweredBy = MessageHeader.CreateHeader(
                                "X-Powered-By", "", "MyApp");
    
                message.Headers.UnderstoodHeaders.Add(poweredBy);
                return message;
            }
    
     }
