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
	
	private SecurityHeaderType GetSecurityHeaderType()
	{
		SecurityHeaderType securityHeader = new SecurityHeaderType();
		DateTime created = DateTime.Now;
		string creationDate;
		creationDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
		string nonce = nonce = (new Random().Next(0, int.MaxValue)).ToString();
		byte[] hashedPassword;
		hashedPassword = GetSHA1(_credentials.SoapSecurity.Password);
		string concatednatedDigestInput = string.Concat(nonce, creationDate, Encoding.Default.GetString(hashedPassword));
		byte[] digest;
		digest = GetSHA1(concatednatedDigestInput);
		string passwordDigest;
		passwordDigest = Convert.ToBase64String(digest);
		string encodedNonce;
		encodedNonce = Convert.ToBase64String(Encoding.Default.GetBytes(nonce));
		XmlDocument doc = new XmlDocument();
		using (XmlWriter writer = doc.CreateNavigator().AppendChild())
		{
			writer.WriteStartDocument();
			writer.WriteStartElement("Security");
			writer.WriteStartElement("UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
			writer.WriteElementString("Username", _credentials.SoapSecurity.Username);
			writer.WriteElementString("Password", passwordDigest);
			writer.WriteElementString("Nonce", encodedNonce);
			writer.WriteElementString("Created", creationDate);
			writer.WriteEndElement();
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Flush();
		}
		doc.DocumentElement.RemoveAllAttributes();
		System.Xml.XmlElement[] headers = doc.DocumentElement.ChildNodes.Cast<XmlElement>().ToArray<XmlElement>();
		securityHeader.Any = headers;
		return securityHeader;
	}
         
