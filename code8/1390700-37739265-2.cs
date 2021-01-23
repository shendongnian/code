    var cacert = File.ReadAllText(@"ca.crt");
    var clientcert = File.ReadAllText(@"client.crt");
    var clientkey = File.ReadAllText(@"client.key");
    var ssl = new SslCredentials(cacert, new KeyCertificatePair(clientcert, clientkey));
    channel = new Channel("localhost", 555, ssl);
    client = new GrpcTest.GrpcTestClient(channel);
