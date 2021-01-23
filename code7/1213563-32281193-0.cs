    public class Client 
    {
        public TcpClient tcpClient;
        public NetworkStream stream;
        public CancellationTokenSource cts = new CancellationTokenSource();
        private byte[] readBuffer = new byte[1024];
        private StringBuilder receiveString = new StringBuilder();
        public Client(TcpClient tcpClient) {
            this.tcpClient = tcpClient;
            this.stream = this.tcpClient.GetStream();
        }
        public async void StartReadAsync(){
            while(await ReadAsync(cts.Token));
        }
        private async Task<bool> ReadAsync(CancellationToken ct) 
        {
            try
            {
                int amountRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, ct);
                if (amountRead > 0)
                {
                    string message = Encoding.UTF8.GetString(readBuffer, 0, amountRead);
                    receiveString.Append(message);
                    Console.WriteLine("Client " + name + " sent: " + message);
                    if (receiveString.ToString().IndexOf(eof) > -1)
                    {
                        // Full message received, otherwise keep reading
                        if (OnClientRead != null)
                            OnClientRead(this, new SocketEventArgs(this, receiveString.ToString()));
                        receiveString.Clear();
                    }
                    return true;
                }
                return false;
            }
            catch { return false; }
            
        }
    }
