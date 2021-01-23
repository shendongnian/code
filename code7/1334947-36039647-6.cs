        public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
        {
            VerifyOperationContext();
            if (contentType.ToLower().StartsWith("multipart/related"))
            {
                byte[] ContentBytes = new byte[stream.Length];
                stream.Read(ContentBytes, 0, ContentBytes.Length);
                MimeContent Content = _MimeParser.DeserializeMimeContent(contentType, ContentBytes);
                if (Content.Parts.Count >= 1)
                {
                    MemoryStream ms = new MemoryStream(Content.Parts[0].Content);
                    //At least for now IRS is sending SOAP envelope as 1st part(and only part(sic!) of MULTIpart response) as xml. 
                    Message Msg = ReadMessage(ms, int.MaxValue, "text/xml");//Content.Parts[0].ContentType);
                    
                    if( Content.Parts.Count>1 )
                        Msg.Properties.Add(ATTCHMNT_PROP, Content.Parts[1].Content);
                    return Msg;
                }
                else
                {
                    throw new ApplicationException("Invalid mime message sent! Soap with attachments makes sense, only, with at least 2 mime message content parts!");
                }
            }
            else if (contentType.ToLower().StartsWith("text/xml"))
            {
                XmlReader Reader = XmlReader.Create(stream);
                return Message.CreateMessage(Reader, maxSizeOfHeaders, MessageVersion);
            }
            else
            {
                throw new ApplicationException(
                    string.Format(
                        "Invalid content type for reading message: {0}! Supported content types are multipart/related and text/xml!",
                        contentType));
            }
        }
