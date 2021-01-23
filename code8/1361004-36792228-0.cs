    private class MyWrappedRestClient : RestClient
    {
        public MyWrappedRestClient(string baseUrl) : base(baseUrl) { }
    
        private IRestResponse<T> Deserialize<T>(IRestRequest request, IRestResponse rawResponse)
        {
            request.OnBeforeDeserialization(rawResponse);
            var restResponse = (IRestResponse<T>)new RestResponse<T>();
            try
            {
                restResponse = rawResponse.ToAsyncResponse<T>();
                restResponse.Request = request;
                if (restResponse.ErrorException == null)
                {
                    restResponse.Data = JsonConvert.DeserializeObject<T>(restResponse.Content);
                }
            }
            catch (Exception ex)
            {
                restResponse.ResponseStatus = ResponseStatus.Error;
                restResponse.ErrorMessage = ex.Message;
                restResponse.ErrorException = ex;
            }
            return restResponse;
        }
    
        public override IRestResponse<T> Execute<T>(IRestRequest request)
        {
            return Deserialize<T>(request, Execute(request));
        }
    }
