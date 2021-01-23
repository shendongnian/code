    public static class NetworkHelper
    {
        public event EventHandler<DnsLookupCompletedEventArgs> DnsLookupCompleted;
        public void DnsLookupAsync(string hostname)
        {
            var endpoint = new DnsEndPoint(hostname, 0);
            DeviceNetworkInformation.ResolveHostNameAsync(endpoint, OnNameResolved, null);  
        }
        private void OnNameResolved(NameResolutionResult result)
        {
            IPEndPoint[] endpoints = result.IPEndPoints;
            var args = new DnsLookupCompletedEventArgs(endpoints);
            if (DnsLookupCompleted != null)
                DnsLookupCompleted(this, args);
        }
    }
