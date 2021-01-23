    -----BEGIN CERTIFICATE-----
    _BASE64 DATA_
    -----END CERTIFICATE-----
    -----BEGIN CERTIFICATE-----
    _BASE64 DATA_
    -----END CERTIFICATE-----
    -----BEGIN CERTIFICATE-----
    _BASE64 DATA_
    -----END CERTIFICATE-----
4. Put these lines to the Dockerfile (in the final steps):
    # Update system and install curl and ca-certificates
    RUN apt-get update && apt-get install -y curl && apt-get install -y ca-certificates
    # Copy your bundle file to the system trusted storage
    COPY ./ca_bundle.crt /usr/local/share/ca-certificates/ca_bundle.crt
    # During docker build, after this line you will get such output: 1 added, 0 removed; done.
    RUN update-ca-certificates
5. In the app:
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
GetClientCertificate method:
    private static X509Certificate2 GetClientCertificate(string clientCertName, string password)
    {
        //Create X509Certificate2 object from .pfx file
    	byte[] rawData = null;
    	using (var f = new FileStream(Path.Combine(AppContext.BaseDirectory, clientCertName), FileMode.Open, FileAccess.Read))
        {
            var size = (int)f.Length;
            var rawData = new byte[size];
            f.Read(rawData, 0, size);
            f.Close();
        }
        return new X509Certificate2(rawData, password);
    }
