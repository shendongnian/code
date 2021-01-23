    private static async Task LoopAndCheckPingAsync(List<string> addresses)
    {
        while (true)
        {
            var pingTasks = addresses.Select(address =>
            {
                var ping = new Ping();
                return ping.SendPingAsync(address);
            });
            await Task.WhenAll(pingTasks);
            StringBuilder pingResultBuilder = new StringBuilder();
            foreach (var pingReply in pingTasks)
            {
                pingResultBuilder.Append(pingReply.Result.Address);
                pingResultBuilder.Append("    ");
                pingResultBuilder.Append(pingReply.Result.Status);
                pingResultBuilder.Append("    ");
                pingResultBuilder.Append(pingReply.Result.RoundtripTime.ToString());
                pingResultBuilder.AppendLine();
            }
            Console.WriteLine(pingResultBuilder.ToString());
            await Task.Delay(TimeSpan.FromMinutes(5));
        }
    }
