        response.ContentLength64 = endpointResponse.Payload.Length;
        response.OutputStream.Write(endpointResponse.Payload, 0, endpointResponse.Payload.Length);
        response.OutputStream.Close();
        foreach (var endpointParameter in endpointResponse.Headers)
        {
            response.AddHeader(endpointParameter.Key, endpointParameter.Value);
        }
        response.StatusCode = endpointResponse.Status;
        response.ContentType = endpointResponse.ContentType;
