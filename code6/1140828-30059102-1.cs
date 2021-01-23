    public Task SendSeveralRequestsAsync(MyClass myClass)
    {
       var client = SomeExternalServiceClient();
       var tasks = myClass
           .Select(item => new ExternalServiceRequest { Value = item.Value })
           .Select(request => client.SendAsync(request));
       return Task.WhenAll(tasks);
    }
