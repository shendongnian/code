    shippingAPIPortTypeClient client = GetProxy();
    <..>
    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
    {
    	var httpRequestProperty = new HttpRequestMessageProperty();
    	httpRequestProperty.Headers.Add(@"X-IBM-Client-Id", _credentials.HttpSecurity.ClientId);
    	httpRequestProperty.Headers.Add(@"X-IBM-Client-Secret", _credentials.HttpSecurity.ClientSecret);
    	OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
    
    	createShipmentResponse response = client.createShipment(GetSecurityHeaderType(), request);
    	return response;
    }
    
    private shippingAPIPortTypeClient GetProxy()
    {
    	// binding comes from configuration file
    	var shippingClient = new shippingAPIPortTypeClient();
    
    	shippingClient.ClientCredentials.UserName.UserName = _credentials.SoapSecurity.Username;
    	shippingClient.ClientCredentials.UserName.Password = _credentials.SoapSecurity.Password;
    
    	shippingClient.ClientCredentials.UseIdentityConfiguration = true;
    
    	foreach (OperationDescription od in shippingClient.Endpoint.Contract.Operations)
    	{
    		od.Behaviors.Add(new RoyalMailIEndpointBehavior());
    	}
    
    	return shippingClient;
    }
         
