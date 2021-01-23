    public bool ConnectedToInternet()
        {
            var myPing = new Ping();
            const string host = "google.com";
            var buffer = new byte[32];
            const int timeout = 1000;
            var pingOptions = new PingOptions();
            var reply = myPing.Send(host, timeout, buffer, pingOptions);
            return reply != null && reply.Status == IPStatus.Success;
        }
