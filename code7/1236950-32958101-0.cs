    public Task<LoginResponse> LoginAsync()
    {
        return SendRequestAsync(new LoginRequest(new Model.Login()));
    }
    private static async Task<TResponse> SendRequestAsync<TResponse>(BaseRequest<TResponse> request) where TResponse : BaseResponse, new()
    {
        try
        {
            return await request.ExecuteAsync();
        }
        catch (Exception e)
        {
            //Log.Error(request.GetType().FullName, e);
            return new TResponse()
            {
                Error = e.InnerException != null ? e.InnerException.Message : e.Message,
                Ok = false
            };
        }
    }
