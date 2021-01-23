    private Task<string> MakeRequest()
    {
        XSoapClient client = new XSoapClient();
        Task<string> request = Task.Factory.FromAsync(
            (callback, state) => c.BeginMyService(PARAM_1, param2, callback, state),
            result => c.EndMyService(result),
            TaskCreationOptions.None);
        Task<string> resultTask = request.ContinueWith(response =>
            {
                return response.Result;
            });
        return resultTask;
    }
    public async Task<string> GetResponse()
    {
        var response = await request();
        return response;
    }
