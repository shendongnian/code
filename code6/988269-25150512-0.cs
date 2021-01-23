    protected virtual string ExecuteIpnResponse(string url)
    {
      var ipnClient = new WebClient();
      var ipnResponse = ipnClient.DownloadString(url);
      return ipnResponse;
    }
