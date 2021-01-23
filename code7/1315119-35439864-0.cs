            private int TCPTimeOut = 10000;
            private int NetStreamTimeOut = 10000;
            private string ipAddress = "";
            private int port;
            private int intThreadSleep;
            private bool disposed = false;
            private TcpClient tcpClient = new TcpClient();
    
            private void GetTCPData()
            {
                tcpClient.Connect(ipAddress, port);
                tcpClient.ReceiveTimeout = TCPTimeOut;
                NetworkStream stream = tcpClient.GetStream();
                stream.ReadTimeout = NetStreamTimeOut;
    
                Byte[] data = new Byte[5210];
                string responseData = String.Empty;
    
                while (true)
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    System.Threading.Thread.Sleep(intThreadSleep);
                    responseData = responseData + System.Text.Encoding.ASCII.GetString(data, 0, bytes);
    
                    if (bytes > 10)
                    {
                        var table = responseData.Split(new string[] { "\r\n", "\r", "\n" },
                                                     StringSplitOptions.None);
    
                        if (table.Count() > 3)
                        {
                            string line1 = table[0];
                            string line2 = table[1];
                            string line3 = table[2];
                            string line4 = table[3];
                            string line5 = table[4];
                            string line6 = table[5];
    
                            // SaveData(ipAddress, line1, line2, line3, line4, line5, line6);
                        }
                    }
                    responseData = String.Empty;
                }
                  
                if (tcpClient != null)
                {
                    tcpClient.GetStream().Close();
                    tcpClient.Close();
                }
    
            }
