    void Receive()
    {
     NewSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, r);
    }
 
     private void ReceiveCallback(IAsyncResult ar)
            {
                Socket CurrentClient = (Socket)ar.AsyncState;
                int Received;
                try { Received = CurrentClient.Receive(buffer); }
                catch
                {
                    return;
                }
    
             
                byte[] _buffer = new byte[Received];
                Array.Copy(buffer, _buffer, Received);
                string _Text = Encoding.Unicode.GetString(_buffer);
    
               if(_Text == "GetVersion")
                byte[] infoVersion = Encoding.Encoding.Default.GetBytes(FILEVERSION);
                  CurrentClient .Send(infoVersion )
    }
