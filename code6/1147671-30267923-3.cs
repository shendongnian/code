    public class LogActionResult : IHttpActionResult
    {
       string uri = /* ... */
       public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
       {
           var response = new HttpResponseMessage()
           {
               Content = new StringContent(_value),
               RequestMessage = _request
           };
           var httpClient = new HttpClient();
           await httpClient.PostAsJsonAsync(uri, response);
           return response;
       }
    }
