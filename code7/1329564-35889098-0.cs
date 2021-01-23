    var binding = new CustomBinding(new BindingElement[] { 
        new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8),
        new HttpTransportBindingElement(),
    });
    serviceHost.AddServiceEndpoint(typeof(Device), binding, "device_service");
    serviceHost.AddServiceEndpoint(typeof(PTZ), binding, "ptz");
