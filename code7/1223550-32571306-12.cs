    var response = request.GetResponse();
    var message = string.Empty;
    using (var responseStreamReader = new StreamReader(response.GetResponseStream()))
    {
        message = responseStreamReader.ReadToEnd();
    }
    var textReader = new StringReader(message);
    var serializer = new XmlSerializer(typeof(ServiceResources));
    var serviceResources = 
        serializer.Deserialize(textReader) as ServiceResources;
