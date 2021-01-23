        private async Task AcceptClientsAsync(TcpListener listener, CancellationToken token)
        {
            var clientCounter = 0;
            while (!token.IsCancellationRequested)
            {
                TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                clientCounter++;
                Console.WriteLine("Client {0} accepted!", clientCounter);
                Task.Run(async () => await EchoAsync(client, clientCounter, token), token);
            }
        }
