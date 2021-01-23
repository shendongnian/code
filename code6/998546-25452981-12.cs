    private static async Task LoopAndCheckPingAsync(List<string> addresses)
    {  
        StringBuilder pingResultBuilder = new StringBuilder();        
        while (true)
        {
             var pingTasks = addresses.Select(address =>
             {
                 using (var ping = new Ping())
                 {
                     return ping.SendPingAsync(address);
                 }
             }).ToList();    
       
            await Task.WhenAll(pingTasks);
            foreach (var pingReply in pingTasks)
            {                pingResultBuilder.Append(pingReply.Result.Address);
                pingResultBuilder.Append("    ");
                pingResultBuilder.Append(pingReply.Result.Status);
                pingResultBuilder.Append("    ");
                pingResultBuilder.Append(pingReply.Result.RoundtripTime.ToString());
                pingResultBuilder.AppendLine();
            }
            Console.WriteLine(pingResultBuilder.ToString());
            pingResultBuilder.Clear();
            await Task.Delay(TimeSpan.FromMinutes(5));
        }
    }
