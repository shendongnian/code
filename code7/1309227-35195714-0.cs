    using System.ServiceModel;
    using System.ServiceModel.Channels;
    
    RemoteEndpointMessageProperty props = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
    ip = props.Address;
