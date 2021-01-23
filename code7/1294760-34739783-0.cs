         public string SocketSendReceive(string server, int port, string cmd)
        {
            byte[] recvBuffer = new byte[1024];
            string host = "127.0.0.1";
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(host, 6100);
            }
            catch (SocketException /*e*/)
            {
                tcpClient = null;
            }
            if (tcpClient != null && tcpClient.Connected)
            {
                
                tcpClient.Client.Send(Encoding.UTF8.GetBytes(cmd));
                tcpClient.Client.Receive(recvBuffer);
                //    port = Convert.ToInt16(Encoding.UTF8.GetString(recvBuffer).Substring(2));
                tcpClient.Close();
            }
            return Encoding.ASCII.GetString(recvBuffer, 0, recvBuffer.Length);
        }
