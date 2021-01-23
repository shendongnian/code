        public static void doSocket()
        {
            try
            {
                TcpListener serverSocket = new TcpListener(Globals.foxProAddress, Globals.foxProPort);
                serverSocket.Start();
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                NetworkStream networkStream = clientSocket.GetStream();
                int bytesRead;
                string buffer = "";
                byte[] bytesFrom = new byte[4096];
            
                while (true)
                {
                    bytesRead = networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                    string dataFromFoxPro = System.Text.Encoding.ASCII.GetString(bytesFrom, 0, bytesRead);
                    buffer = buffer + dataFromFoxPro;
                    // look at buffer and see if it has one or more complete "messages":
                    while (buffer.Contains("something")) // made up protocol
                    {
                        string msg = buffer.Substring(0, buffer.IndexOf("something")); // extract the message <-- completely made up
                        buffer = buffer.Remove(0, msg.Length); // remove the msg from the beginning of the buffer <-- pseudo-code!
                        Payments.startTransaction(msg);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
