    private void recieveText()
    {
        //initialise multicast group and bind to interface
        Socket _listener_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, _PORT);
        _listener_socket.Bind(ipep);
        IPAddress localip = IPAddress.Parse("224.5.6.7");
        _listener_socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(localip, IPAddress.Any));
 
        //recieve data to multicast group
        while (_listener_socket.IsBound)
        {
            updateLabel("listening...");
            byte[] b = new byte[1024];
            updateLabel("message recieved");
            updateRedBox("\n---------------------------------\n New Message :\n");
            EndPoint IPEPoint = (EndPoint)ipep;
            var res = _listener_socket.BeginReceiveMessageFrom(b, 0, b.Length, 0, ref IPEPoint, null, null);
            SocketFlags flags = SocketFlags.None;
            IPPacketInformation packetInfo;
            _listener_socket.EndReceiveMessageFrom(res, ref flags, ref IPEPoint, out packetInfo);
            updateRedBox(IPEPoint.ToString());
            char[] chars = new char[b.Length / sizeof(char)];
            System.Buffer.BlockCopy(b, 0, chars, 0, b.Length);
 
            string t = new string(chars).Trim();
            updateRedBox(t);
            updateRedBox("\n----------------------------------\n");
        }
    }
 
