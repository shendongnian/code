            while (true)
            {
                //Accept a new connection
                Socket mySocket = _listener.AcceptSocket();
                if (mySocket.Connected)
                {
                    StringBuilder sb = new StringBuilder();
                    Byte[] bReceive = new Byte[1024];
                    int i;
                    while ((i = mySocket.Receive(bReceive, bReceive.Length, 0) > 0))
                    {
                        sb.Append(Encoding.ASCII.GetString(bReceive, 0, i)); // added index and count
                    }
                    string sBuffer = sb.ToString();
                    if (sBuffer.Substring(0, 3) != "GET")
                    {
                        Console.WriteLine(sBuffer);
                        mySocket.Close();
                        return;
                    }
                }
            }
