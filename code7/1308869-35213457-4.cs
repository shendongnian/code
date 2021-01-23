            using (new OperationContextScope(transmitterClient.InnerChannel))
            {
                // Add a HTTP Header to an outgoing request
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers["Content-Encoding"] = "gzip";
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                return port.BulkRequestTransmitter(request);
            }
