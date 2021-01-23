    public void Listen()
    {
        if (mDisposing == true)
        {
            throw new ObjectDisposedException(null, "This instance is already disposed");
        }
        if (mListening == false)
        {
            try
            {
                mListening = true;
                ServerEndPoint = new IPEndPoint(ServerAddress, Port);
                mServerSocket = new Socket(ServerAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                var sioUdpConnectionReset = -1744830452;
                var inValue = new byte[] { 0 };
                var outValue = new byte[] { 0 };
                mServerSocket.IOControl(sioUdpConnectionReset, inValue, outValue);
                mServerSocket.Bind(ServerEndPoint);
                if (ServerAddress.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    OperatingSystem os = Environment.OSVersion;
                    Version version = os.Version;
                    // NOTE: Windows Vista or higher have one IP stack for IPv4 and IPv6
                    // Therefore they can be combined and used as one socket for IPv6
                    // The socket must then accept both IPv4 and IPv6 connections.
                    if (version.Major > 5)
                    {
                        // NOTE: IPV6_V6ONLY socket option is equivalent to 27 in the winsock snippet below
                        // This is available in Framework 4.0. A lower version can implement (SocketOptionName)27
                        mServerSocket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, 0);
                    }
                }
                var ipeSender = new IPEndPoint(IPAddress.Any, 0);
                var endPointSender = (EndPoint)ipeSender;
                mServerSocket.BeginReceiveFrom(mByteData, 0, mByteData.Length, SocketFlags.None, ref endPointSender, new AsyncCallback(OnDataReceived), null);
            }
            catch (Exception exception)
            {
                mListening = false;
                DoError(exception);
            }
        }
        else
        {
            var ipeSender = new IPEndPoint(IPAddress.Any, 0);
            var endPointSender = (EndPoint)ipeSender;
            mServerSocket.BeginReceiveFrom(mByteData, 0, mByteData.Length, SocketFlags.None, ref endPointSender, new AsyncCallback(OnDataReceived), null);
        }
    }
