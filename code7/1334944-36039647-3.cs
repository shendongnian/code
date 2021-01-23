    public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
            {
                ArraySegment<byte> buffer = innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, 0);
                var requestSOAPEnvelopeXml = System.Text.Encoding.UTF8.GetString(buffer.Array);
				
				//Here you create Security node and sign the request. For ex:
				requestSOAPEnvelopeXml = SigngEnvelope(requestSOAPEnvelopeXml);
				//Here you are getting 1094\1095 forms xml payload.
				string fileContent = GetAttachmentFileContent();
				
				//Here comes the MTOMing...
				_SoapMimeContent.Content = System.Text.Encoding.UTF8.GetBytes(requestSOAPEnvelopeXml);
                _AttachmentMimeContent.Content = System.Text.Encoding.UTF8.GetBytes(fileContent);
                _MyContent.Parts.Where(m=> m.ContentId!=null && m.ContentId.Equals(ATTCHMNT_CONTENT_ID)).Single().ContentDisposition = GetFileName(envelope);
                // Now create the message content for the stream
                byte[] MimeContentBytes = _MimeParser.SerializeMimeContent(_MyContent);
                int MimeContentLength = MimeContentBytes.Length;
                // Write the mime content into the section of the buffer passed into the method
                byte[] TargetBuffer = bufferManager.TakeBuffer(MimeContentLength + messageOffset);
                Array.Copy(MimeContentBytes, 0, TargetBuffer, messageOffset, MimeContentLength);
                // Return the segment of the buffer to the framework
                return CompressBuffer(new ArraySegment<byte>(TargetBuffer, messageOffset, MimeContentLength), bufferManager, messageOffset);				
			}
			
