    // Called from the main method.
    // 'request' is the BulkRequestTransmitterRequest object where the BusinessHeader, 
    // Manifest, Security, and FormData are set.
    ACABulkRequestTransmitterResponseType response = SubmitRequest(request).ACABulkRequestTransmitterResponse;
    private static BulkRequestTransmitterResponse SubmitRequest(BulkRequestTransmitterRequest request)
    {
        // Create a new instance of the Web Service client object.
        BulkRequestTransmitterPortTypeClient client = new BulkRequestTransmitterPortTypeClient("BulkRequestTransmitterPort");
    
        using (new OperationContextScope(client.InnerChannel))
        {
            // Add a HTTP Header to an outgoing requqest.
            HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
    
            requestMessage.Headers["Content-Encoding"] = "gzip";
                                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
    
            return client.BulkRequestTransmitter(request);
        }
    }
