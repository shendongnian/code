    private async Task LoopAndCheckPingAsync(List<string> addresses)
    {
         while (true)
         {
            var ping = new Ping();
            var pingTasks = addresses.Select(address => ping.SendPingAsync(address));
            await Task.WhenAll(pingTasks);
            StringBuilder pingResultBuilder = new StringBuilder();
            foreach (var pingReply in pingTasks)
            {
               pingResultBuilder.Append(pingReply.Address);
                pingResultBuilder.Append("    ");
                pingResultBuilder.Append(pingReply.Status);
                pingResultBuilder.Append("    ");
          pingResultBuilder.Append(pingReply.RoundtripTime.ToString());
                pingResult.AppendLine();
          }
         
          Console.WriteLine(pingResult.ToString());
          await Task.Delay(TimeSpan.FromMinutes(5)); \\ Change this interval to the desired interval time.
        }
    }
