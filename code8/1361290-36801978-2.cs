    string url = @"..."; // Replace with your actual URL.
    IList<BusinessFunctionData> outputlist;
    WebRequest request = WebRequest.Create(url);
    using (var response = request.GetResponse())
    using (var responseStream = response.GetResponseStream())
    {
        var settings = new JsonSerializerSettings { ContractResolver = ArrayToSingleContractResolver.Instance, NullValueHandling = NullValueHandling.Ignore };
        outputlist = JsonExtensions.DeserializeNamedProperties<List<BusinessFunctionData>>(responseStream, "result", settings).FirstOrDefault();
    }
