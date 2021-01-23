        private void recieveText(string _IPADDRESS)
        {
            //initialise multicast group and bind to interface
            Socket _listener_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, _PORT);
            _listener_socket.Bind(ipep);
            IPAddress localip = IPAddress.Parse("224.5.6.7");
            _listener_socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(localip, IPAddress.Any));
            ThreadPool.QueueUserWorkItem((o) =>
            {
                BeginInvoke((Action)(() => { label1.Text = "listening..."; }));
                while (_listener_socket.Connected)
                {
                
                    byte[] b = new byte[1024];
                    _listener_socket.Receive(b);
                    char[] chars = new char[b.Length / sizeof(char)];
                    System.Buffer.BlockCopy(b, 0, chars, 0, b.Length);
                    string t = new string(chars).Trim();
                    BeginInvoke((Action)(() =>
                    {
                        label1.Text = "message recieved";
                        redBox.AppendText("\n---------------------------------\n New Message :\n");
                        redBox.AppendText(t);
                        redBox.AppendText("\n----------------------------------\n\n");
                    }));
                }
            });
        }
