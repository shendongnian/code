    public class MonitoringDelegate : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
        var watcher = Stopwatch.StartNew();
        var response = await base.SendAsync(request, cancellationToken);
        watcher.Stop();
        //log/store duration using watcher.ElapsedMilliseconds
        return response;
        }
    }
