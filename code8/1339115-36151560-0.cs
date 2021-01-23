    var client = new ServiceClient();
    client.Endpoint.Address = new EndpointAddress(url);
    
    BasicHttpBinding binding = client.Endpoint.Binding as BasicHttpBinding;
    binding.Security.Mode = BasicHttpSecurityMode.Transport;
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
    
    client.ClientCredentials.ClientCertificate.Certificate = ...
