        private IRestResponse Execute(IRestRequest request, string httpMethod,
            Func<IHttp, string, HttpResponse> getResponse)
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
So with that you know that you can expect standard .net exceptions. The <a href="https://github.com/restsharp/RestSharp/wiki/Recommended-Usage">recommended usage</a> suggests just checking for the existence of an ErrorException like in the code example.
//Snippet of code example in above link
var response = client.Execute<T>(request);
        if (response.ErrorException != null)
        {
            const string message = "Error retrieving response.  Check inner details for more info.";
            var twilioException = new ApplicationException(message, response.ErrorException);
            throw twilioException;
        }</code></pre>
If you want to preform a specific action on a certain kind of exception just preform a type comparison using a line like the following. 
if (response.ErrorException.GetType() == typeof(NullReferenceException)){}
