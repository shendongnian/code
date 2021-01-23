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
 
        // Create a basic request
        var request = new BasicRequest(dto, RequestAttributes.None);
        // Execute the request
		return HostContext.ServiceController.Execute(dto, request);
    }
