    private void Foo()
    {
        datagramSocket = new DatagramSocket();
        datagramSocket.MessageReceived += OnMessageReceived;
        await datagramSocket.BindServiceNameAsync("8081");
    }
    private void OnMessageReceived(
        DatagramSocket sender,
        DatagramSocketMessageReceivedEventArgs args)
    {
        // ...
    }
