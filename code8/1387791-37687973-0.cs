    WSHttpBinding binding = new WSHttpBinding();
    EndpointAddress endpoint = new EndpointAddress(new Uri("https://my.service.com/WCFServices/Info.svc"));
    
    
    binding.Name = "WSHttpBinding_IInfo";
    binding.MessageEncoding = WSMessageEncoding.Mtom;
    binding.Security = new WSHttpSecurity();
    binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
    binding.Security.Transport = new HttpTransportSecurity();
    binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
    binding.Security.Message = new NonDualMessageSecurityOverHttp();
    binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
    binding.Security.Message.EstablishSecurityContext = false;
    
    							   
    
    InfoClient proxy = new InfoClient(binding, endpoint);
    
    
    proxy.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My,													X509FindType.FindBySubjectName, "This is my TEST Cert");
    
    object response = proxy.ServiceMethod();
