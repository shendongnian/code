    private async Task SendAliveMessageAsync();
    public Task KeepaliveTask { get; private set; }
    public Client()
    {
      ...
      KeepaliveTask = SendAliveMessageAsync();
    }
