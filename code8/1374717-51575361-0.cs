    public static class AzureFunctionDemo
    {
        [FunctionName("MyAwesomeFunction")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            string cs;  
            try
            {
                cs = Environment.GetEnvironmentVariable("MyConnectionString", EnvironmentVariableTarget.Process);
            }
            catch
            {
                return req.CreateResponse(HttpStatusCode.BadRequest, "MyConnectionString is not setup");
            }
            return req.CreateResponse(HttpStatusCode.Ok, cs);
        }
    }
