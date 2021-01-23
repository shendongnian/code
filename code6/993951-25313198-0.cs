    public class PerformanceHandler : DelegatingHandler
        {
            protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
    
                request.Properties.Add(new KeyValuePair<string, object>("Stopwatch", stopwatch));
    
                var response = await base.SendAsync(request, cancellationToken);
    
                Log(request, response);
    
                return response;
    
            }
       }
