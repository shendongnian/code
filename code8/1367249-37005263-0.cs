    private async void ConnectToTimeServer(object sender, RoutedEventArgs e)
    {
        var socket = new DatagramSocket();
        socket.MessageReceived += SocketMessageReceived;
        await socket.ConnectAsync(new HostName("time.windows.com"), "123");
    
        using (var dataWriter = new DataWriter(socket.OutputStream))
        {
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;
            dataWriter.WriteBytes(ntpData);
            await dataWriter.StoreAsync();
        }
    }
