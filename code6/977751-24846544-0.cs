        struct Status
        {
            public IPAddress IpAddress;
            public bool? IsAlive;
        }
        private Status[] ipAddresses = new Status[]
        {
            new Status()
            {
                IpAddress = IPAddress.Parse("192.168.1.1")
            },
            new Status()
            {
                IpAddress = IPAddress.Parse("192.168.1.2")
            },
            new Status()
            {
                IpAddress = IPAddress.Parse("192.168.1.3")
            },
        };
        private void scanPorts()
        {
            Parallel.ForEach(ipAddresses, (ipAddress) =>
                {
                    IPEndPoint ipEndPoint = new IPEndPoint(ipAddress.IpAddress, 80);
                    Socket socket = new Socket(AddressFamily.InterNetwork, 
                                               SocketType.Stream,
                                               ProtocolType.Tcp);
                    try
                    {
                        socket.Connect(ipEndPoint);
                        socket.Disconnect(true);
                        ipAddress.IsAlive = true;
                    }
                    catch (SocketException)
                    {
                        ipAddress.IsAlive = false;
                    }
                });
        }
