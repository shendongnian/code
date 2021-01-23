    public void Main()
    {
      byte[] incomingMessage = ....; // LOH
      string json = Encoding.UTF8.GetString(incomingMessage); // another LOH
      var desj = JsonSerializer.Deserialize(json);
      Console.Writeline("Get snapshot");
      Console.ReadLine();
     
      // prevent GC to collect them
      GC.KeepAlive(incomingMessage);
      GC.KeepAlive(json);
      GC.KeepAlive(desj);
    }
