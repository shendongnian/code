    private async Task GetDataFromAzureAsync()
    {
        var arguments = new Dictionary<string, string>();
        arguments.Add("input", "TestInput");
        System.Diagnostics.Debug.WriteLine("Before await!!!!!!!!!!!!!");
        var resultDoe = await MobileService.InvokeApiAsync<string>("NameOfController", System.Net.Http.HttpMethod.Get, arguments);
        System.Diagnostics.Debug.WriteLine("End Of GetDataFromAzure!!!!!!!!!!!!!! " + resultDoe);
    }
