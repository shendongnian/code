        class Status
        {
            public IPAddress IpAddress { get; set; }
            public bool? IsAlive { get; set; }
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
            Parallel.ForEach(ipAddresses, scanPort);
        }
        private void scanPort(Status status)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(status.IpAddress, 80);
            Socket socket = new Socket(AddressFamily.InterNetwork,
                                       SocketType.Stream,
                                       ProtocolType.Tcp);
            try
            {
                socket.Connect(ipEndPoint);
                socket.Disconnect(true);
                status.IsAlive = true;
            }
            catch (SocketException)
            {
                status.IsAlive = false;
            }
        }
