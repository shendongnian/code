    private IRestResponse Execute(IRestRequest request, string httpMethod,Func<IHttp, string, HttpResponse> getResponse)
    {
        AuthenticateIfNeeded(this, request);
        IRestResponse response = new RestResponse();
        try
        {
            var http = HttpFactory.Create();
    
            ConfigureHttp(request, http);
    
            response = ConvertToRestResponse(request, getResponse(http, httpMethod));
            response.Request = request;
            response.Request.IncreaseNumAttempts();
    
        }
        catch (Exception ex)
        {
            response.ResponseStatus = ResponseStatus.Error;
            response.ErrorMessage = ex.Message;
            response.ErrorException = ex;
        }
    
        return response;
    }
