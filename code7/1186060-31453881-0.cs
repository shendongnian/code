    private async Task<PingReply> PingAndProcessAsync(Ping pingSender, string ip)
    {
      var result = await pingSender.SendPingAsync(ip, 2000);
      ProcessPingResult(result);
      return result;
    }
