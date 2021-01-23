    public class WebApiRateLimitHandler : DelegatingHandler {
    
        //Override the SendAsync Method to tap into request pipeline
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            Debug.WriteLine("Process request");
            // Call the inner handler.
            Task<HttpResponseMessage> response = base.SendAsync(request, cancellationToken);
            Debug.WriteLine("Process response");
            return response.ContinueWith(task => {
                var httpResponse = task.Result;
                httpResponse.Headers.Add("X-App-Limit-Remaining", getRemainingCalls());
                return httpResponse;
            });        
        }
    }
