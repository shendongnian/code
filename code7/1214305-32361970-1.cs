    RestClient client = new RestClient(urlService);
    RestRequest request = new RestRequest
    {
        Method = Method.GET,
        RequestFormat = DataFormat.Xml,
        Resource = "GetMultimedia/{id}"
    };
    request.AddParameter("id", idMultimedia, ParameterType.UrlSegment);
    string tempFile = Path.GetTempFileName();
    using (var writer = File.OpenWrite(tempFile))
    {
        request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
        var response = client.DownloadData(request);
        if (!response.StatusCode != HttpStatusCode.OK)
            # do something
    }
