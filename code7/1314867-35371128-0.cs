    public class TCPClientNew
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] _recieveBuffer = new byte[8142];
        private void Connect()
        {
            bool isConnected = false;
            while (!isConnected)
            {
                try
                {
                    _clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, 4444));
                    isConnected = true;
                }
                catch (SocketException ex)
                {
                    Debug.Log(ex.Message);
                    // Wait 1 second before trying to connect again
                    Thread.Sleep(1000);
                }
            }
            
            // We are now connected, start to receive
            _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            //Check how much bytes are recieved and call EndRecieve to finalize handshake
            try
            {
                int recieved = _clientSocket.EndReceive(AR);
                if (recieved <= 0)
                    return;
                //Copy the recieved data into new buffer , to avoid null bytes
                byte[] recData = new byte[recieved];
                Buffer.BlockCopy(_recieveBuffer, 0, recData, 0, recieved);
                //Start receiving again
                _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (SocketException ex)
            {
                Debug.Log(ex.Message);
                // If the socket connection was lost, we need to reconnect
                if (!_clientSocket.Connected)
                {
                    Connect();
                }
                else
                {
                    //Just a read error, we are still connected
                    _clientSocket.BeginReceive(_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
                }
            }
        }
        private void SendData(byte[] data)
        {
            SocketAsyncEventArgs socketAsyncData = new SocketAsyncEventArgs();
            socketAsyncData.SetBuffer(data, 0, data.Length);
            _clientSocket.SendAsync(socketAsyncData);
        }
    }
