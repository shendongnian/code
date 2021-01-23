    WebRequestHandler handler = new WebRequestHandler();
    X509Certificate2 certificate = GetMyX509Certificate();
    handler.ClientCertificates.Add(certificate);
    HttpClient client = new HttpClient(handler);
    var request = new HttpRequestMessage (HttpMethod.Get, "myapi/?myParm=" + aParm);
    HttpResponseMessage response = await client.SendAsync (request);
    response.EnsureSuccessStatusCode();
