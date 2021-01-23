            using (new OperationContextScope(transmitterClient.InnerChannel))
            {
                // Add a SOAP Header to an outgoing request
                MessageHeader aMessageHeader = MessageHeader.CreateHeader("content-encoding", "http://tempuri.org", "gzip");
                OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);
                // Add a HTTP Header to an outgoing request
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Content-Encoding"] = "gzip";
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                return port.BulkRequestTransmitter(request);
            }
