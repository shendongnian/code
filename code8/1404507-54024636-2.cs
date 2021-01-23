    var address = new EndpointAddress("https://serviceUrl");                
    var binding = new BasicHttpsBinding
    {
        CloseTimeout = new TimeSpan(0, 1, 0),
        OpenTimeout = new TimeSpan(0, 1, 0),
        ReceiveTimeout = new TimeSpan(0, 1, 0),
        SendTimeout = new TimeSpan(0, 1, 0),
        MaxBufferPoolSize = 524288,
        MaxBufferSize = 65536,
        MaxReceivedMessageSize = 65536,
        TextEncoding = Encoding.UTF8,
        TransferMode = TransferMode.Buffered,
        UseDefaultWebProxy = true,
        AllowCookies = false,
        BypassProxyOnLocal = false,
        ReaderQuotas = XmlDictionaryReaderQuotas.Max,
        Security =
        {
            Mode = BasicHttpsSecurityMode.Transport,
            Transport = new HttpTransportSecurity
            {
                ClientCredentialType = HttpClientCredentialType.Certificate,
                ProxyCredentialType = HttpProxyCredentialType.None
            }
        }
    };
    var client = new MyWSClient(binding, address);
    client.ClientCredentials.ClientCertificate.Certificate = GetClientCertificate("clientCert.pfx", "passwordForClientCert");
    // Client certs must be installed
    client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication
    {
        CertificateValidationMode = X509CertificateValidationMode.ChainTrust,
        TrustedStoreLocation = StoreLocation.LocalMachine,
        RevocationMode = X509RevocationMode.NoCheck
    };
