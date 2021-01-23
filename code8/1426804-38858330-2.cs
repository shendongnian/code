    private async Task Listen()
    {
        while (true)
        {
            //expects a 4 byte packet representing a command
            Debug.WriteLine($"Listening for socket command...");
            IBuffer inbuffer = new Windows.Storage.Streams.Buffer(4);
            await _socket.InputStream.ReadAsync(inbuffer, 4, InputStreamOptions.None);
            int command = BitConverter.ToInt32(inbuffer.ToArray(), 0);
            
            Debug.WriteLine($"Command received: {command}");
            ParseCommand(command);
        }
    }
    
    private async void ParseCommand(int command)
    {
        //...
    }
