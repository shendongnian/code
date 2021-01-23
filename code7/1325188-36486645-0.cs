    var deviceClient = DeviceClient.CreateFromConnectionString("<DeviceConnectionString>");
    while(true)
    {
        await Task.Delay(1000);
        var receivedMessage = await deviceClient.ReceiveAsync(TimeSpan.FromSeconds(1));
        if (receivedMessage != null)
        {
            var messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
            Console.WriteLine("\t{0}> Received message: {1}", DateTime.Now.ToLocalTime(), messageData);
            await deviceClient.CompleteAsync(receivedMessage);
        }
    }
