    static async Task SendMessageToServerAsync(string message)
    {
        var byteArray = MessageToByteArray(message, Encoding.UTF8);
        using (var tcpClient = new TcpClient())
        {
            tcpClient.Connect("127.0.0.1", 5000);
            using (var networkStream = tcpClient.GetStream())
            {
                await networkStream.WriteAsync(byteArray, 0, byteArray.Length);
                byte[] read_buffer = new byte[50];
                int read = await networkStream.ReadAsync(read_buffer, 0, read_buffer.Length);
                // do something with the read_buffer
            }
        }
    }
