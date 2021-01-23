    private async void Listen()
    {
        try
        {
            while (true)
            {
                Socket socket = await this.server.AcceptSocketAsync();
                if (socket == null)
                {
                    break;
                }
                Task.Run(() => this.ClientThread(socket));
            }
        }
        catch (ObjectDisposedException)
        {
            Log.Debug("Media HttpServer closed.");
        }
    }
