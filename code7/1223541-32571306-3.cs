    static void Main(string[] args)
    {
        var restUri = CreateRestUri();
        var clientCert = GetX509FromPersonalStore();
        var request = (HttpWebRequest)HttpWebRequest.Create(restUri);
        request.Headers.Add("x-ms-version", "2012-03-01");
        request.ClientCertificates.Add(clientCert);
        var response = request.GetResponse();
        using (var responseStreamReader = new StreamReader(response.GetResponseStream()))
        {
            var message = responseStreamReader.ReadToEnd();
            var textReader = new StringReader(message);
            var serializer = new XmlSerializer(typeof(ServiceResources));
            var o = serializer.Deserialize(textReader);
        }
    }
