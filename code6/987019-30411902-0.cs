    using (Client client = new Client(server.IPAddress.ToString(), server.Port, new System.Threading.CancellationToken()))
    {
      await client.TryLoginAsync("username", "password", TimeoutMs);
      client.WriteLine("whatever command you want to send");
      string response = await client.TerminatedReadAsync(">", TimeSpan.FromMilliseconds(TimeoutMs));
    }
