    static object CallInternalService(string path, string method = "GET", string jsonData = null)
    {
        // Determine the request dto type based on the rest path
        var restPath = HostContext.ServiceController.GetRestPathForRequest(method, path);
        if(restPath == null || restPath.RequestType == null)
            throw new Exception("No route matched the request"); // Note no fallbacks
        // Create an instance of the dto
        var dto = Activator.CreateInstance(restPath.RequestType);
        if(jsonData != null)
        {
            var data = ServiceStack.Text.JsonSerializer.DeserializeFromString(jsonData, restPath.RequestType);
            dto.PopulateWith(data);
        }
        // Create an internal request
        var request = new InternalRequest {
            Verb = method,
            Dto = dto,
            ContentType = "application/json",
            UserAgent = "InternalRequestService",
            Cookies = new Dictionary<string, Cookie>(),
            ResponseContentType = "application/json",
            HasExplicitResponseContentType = true,
            Items = new Dictionary<string, object>(),
            Headers = new NameValueCollectionWrapper(new NameValueCollection()),
            QueryString = new NameValueCollectionWrapper(new NameValueCollection()),
            FormData = new NameValueCollectionWrapper(new NameValueCollection()),
            RawUrl = path,
            AbsoluteUri = path,
            UserHostAddress = "127.0.0.1",
            RemoteIp = "127.0.0.1",
            AcceptTypes = new[] { "application/json" },
            PathInfo = path,
        };
        // Get the service for the request type
        var service = HostContext.ServiceController.GetService(restPath.RequestType);
        // Invoke the method passing in the request and the dto, and return the reply
        return service.Invoke(request, dto);
    }
