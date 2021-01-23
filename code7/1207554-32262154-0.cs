     foreach (IPAddress ip in allLocalNetworkAddresses.AddressList)
            {
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //Allow sending broadcast messages
                client.SetSocketOption(SocketOptionLevel.Socket,
                SocketOptionName.Broadcast, 1);
                //Bind on port 0. The OS will give some port between 1025 and 5000.
              //  client.Bind(new IPEndPoint(ip, 0));
                //Create endpoint, broadcast.
                IPEndPoint AllEndPoint = new IPEndPoint(IPAddress.Broadcast, Port);   
                byte[] sendData = Encoding.ASCII.GetBytes("1");
                
                client.SendTo(sendData, AllEndPoint);
                Console.Write("Client send '1' to " + AllEndPoint.ToString() +
                Environment.NewLine);
