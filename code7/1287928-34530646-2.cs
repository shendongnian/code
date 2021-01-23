            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            if (_localIp != null)
                _socket.Bind(new IPEndPoint(_localIp, 0));
            _socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
            var receiveAllOn = BitConverter.GetBytes(1);
            _socket.IOControl(IOControlCode.ReceiveAll, receiveAllOn, null);
            _socket.ReceiveBufferSize = (1 << 16);
            Read();
