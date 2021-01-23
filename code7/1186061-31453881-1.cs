    private async Task<List<PingReply>> PingAsync()
    {
      Ping pingSender = new Ping();
      var tasks = theListOfIPs.Select(ip => PingAndProcessAsync(pingSender, ip));
      var results = await Task.WhenAll(tasks);
      return results.ToList();
    }
