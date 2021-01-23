    public static string ReceiveMessage(string ipAddress, string port, int bufferSize = 1024)
    {
        try
        {
            TcpListener serverSocket = new TcpListener(new System.Net.IPAddress(IPAddress.Parse(ipAddress).GetAddressBytes()), Int32.Parse(port));
            serverSocket.Start();
            TcpClient clientSocket = serverSocket.AcceptTcpClient();
            NetworkStream networkStream = clientSocket.GetStream();
            int bytesRead;
            string buffer = "";
            byte[] bytesFrom = new byte[bufferSize];
            while (true)
            {
                bytesRead = networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                string incoming = System.Text.Encoding.ASCII.GetString(bytesFrom, 0, bytesRead);
                buffer = buffer + incoming;
                while (buffer.Contains("~"))
                {
                    string msg = buffer.Substring(0, buffer.IndexOf("~"));
                   // buffer = buffer.Remove(0, msg.Length + 3);
                    return msg;
                }
            }
            //var socket = new TcpListener(new IPAddress(IPAddress.Parse(ipAddress).GetAddressBytes()), Int32.Parse(port));
            //try
            //{
            //byte[] buffer = new byte[bufferSize];
            //    Receive(socket, buffer, 0, buffer.Length, 10000);
            //    socket.Close();
            //    return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            //}
            //catch (Exception e)
            //{
            //    socket.Close();
            //    return e.Message;
            //}
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
