    public Task<IRestResponse<T>> SendRequest<T>(string url, string bodyJson)
    {
        var client = new RestClient(url);
    
        var request = new RestRequest
        {
            RequestFormat = DataFormat.Json;
            Method = Method.POST;
        };
        request.AddBody(bodyJson);
    
        var taskCompletionSource = new TaskCompletionSource<IRestResponse<MyClass>>();
    
        client.ExecuteAsync<T>(request, response =>
        {
            taskCompletionSource.SetResult(response);
        });
    
        return taskCompletionSource.Task;
    }
    // Create temp obj
    dynamic employee = new ExpandoObject();
    employee.Name = "John Smith";
    employee.Age = 33;
