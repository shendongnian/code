    public class CorsHeaderHandler : DelegatingHandler
    {
        private const string OPTIONSMETHOD = "OPTIONS";
        private const string ORIGINHEADER = "ORIGIN";
        private const string ALLOWEDORIGIN = "https://yourspodomain.sharepoint.com";
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var allowedOrigin = request.Headers.Any(t => t.Key == ORIGINHEADER && t.Value.Contains(ALLOWEDORIGIN));
                if (allowedOrigin == false) return task.Result;
                if (request.Method == HttpMethod.Options)
                {
                    var emptyResponse = new HttpResponseMessage(HttpStatusCode.OK);
                    emptyResponse.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");
                    emptyResponse.Headers.Add("Access-Control-Allow-Origin", ALLOWEDORIGIN);
                    emptyResponse.Headers.Add("Access-Control-Allow-Credentials", "true");
                    emptyResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                    return emptyResponse;
                }
                else
                {
                    task.Result.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");
                    task.Result.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
                    return task.Result;
                }
            });
        }
    }
