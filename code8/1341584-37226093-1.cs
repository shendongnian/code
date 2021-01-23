    // Grab Certificate
    X509Certificate2 cert2 = new X509Certificate2(
       AppDomain.CurrentDomain.BaseDirectory + "CertificateName.p12",
        CertificatePasswordHere,
        X509KeyStorageFlags.MachineKeySet);
    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://adfapi.adftest.rightmove.com/v1/property/sendpropertydetails");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";
    httpWebRequest.ClientCertificates.Clear();
    httpWebRequest.ClientCertificates.Add(cert2);
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        streamWriter.Write(data);
        streamWriter.Flush();
        streamWriter.Close();
    }
    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
    }
