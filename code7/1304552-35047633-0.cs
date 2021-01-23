    public void MakeRequest()
    {
        using (var client = new ApiClient(Credentials.ApiKey))
        {
            client.DoSomething();
        }
    }
