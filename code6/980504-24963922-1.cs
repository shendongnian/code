    TcpListener tcpListener = new TcpListener(IPAddress.Any, serverTCPPort);
                    tcpListener.Start();
                    string received = "";
                    while (true)
                    {
                        tcpClient = tcpListener.AcceptTcpClient();
    
                        stream = tcpClient.GetStream();
                        reader = new StreamReader(stream);
                        writer = new StreamWriter(stream);
                        writer.NewLine = "\r\n";
                        writer.AutoFlush = true;
                        byte[] bytes = new byte[tcpClient.SendBufferSize];
                        int recv = 0;
                        while (true)
                        {
                            recv = stream.Read(bytes, 0, tcpClient.SendBufferSize);
                            received += System.Text.Encoding.ASCII.GetString(bytes, 0, recv);
    
                            if (received.EndsWith("\n\n"))
                            {
                                break;
                            }
                        }
    }
