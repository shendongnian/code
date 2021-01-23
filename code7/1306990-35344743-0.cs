        using (new OperationContextScope(transmitter.InnerChannel))
        {
        // Add a HTTP Header to an outgoing request
        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
        requestMessage.Headers["Content-Encoding"] = "gzip";
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
        
        var response = transmitter.BulkRequestTransmitter(
            securityHeader,
            security,
            ref businessHeader,
            transmitterManifestReqDtl,
            transmitterType);
        ParseSubmitResponse(response);
        }
