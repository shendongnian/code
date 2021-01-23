    var certificate = await CertificateStores.FindAllAsync(new CertificateQuery() { FriendlyName = "MyFriendlyName" });
    ClientCert = certificate.Single();
    HttpBaseProtocolFilter aHBPF = new HttpBaseProtocolFilter();
    aHBPF.ClientCertificate = ClientCert;
    // Create our http client and send the request.
    HttpClient httpClient = new HttpClient(aHBPF);
    HttpResponseMessage response = await httpClient.SendRequestAsync(httpRequest, HttpCompletionOption.ResponseHeadersRead).AsTask(cts.Token);
