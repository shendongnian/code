    var properties = OperationContext.Current.IncomingMessageProperties;
    var endpointProperty = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
    if (endpointProperty != null)
    {
        var ip = endpointProperty.Address;
    }
