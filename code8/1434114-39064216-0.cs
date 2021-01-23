            byte[] TotalData = new byte[0];
            byte[] TempData = new byte[0];
            using (TcpClient TCPClient = new TcpClient())
            {
                try
                {
                    TCPClient.Connect(somehost, someport);
                }
                catch (Exception eee)
                {
                    // Report the connection failed in some way if necessary
                }
                if (TCPClient.Connected)
                {
                    using (NetworkStream clientStream = TCPClient.GetStream())
                    {
                        // You can reduce the size of the array if you know 
                        // the data received is going to be small, 
                        // don't forget to change it a little down too
                        byte[] TCPBuffer = new byte[524288];
                        int bytesRead = 0;
            
                        int loop = 0;
                        // Wait for data to begin coming in for up to 20 secs
                        while (!clientStream.DataAvailable && loop< 2000)
                        {
                            loop++;
                            Thread.Sleep(10);
                        }
                        // Keep reading until nothing comes for over 1 sec
                        while (clientStream.DataAvailable)
                        {
                            bytesRead = 0;
            
                            try
                            {
                                bytesRead = clientStream.Read(TCPBuffer, 0, 524288);
                                Array.Resize(ref TempData, bytesRead);
                                Array.Copy(TCPBuffer, TempData, bytesRead);
                                // Add data to TotalData
                                TotalData = JoinArrays(TotalData, TempData);
                            }
                            catch
                            {
                                break;
                            }
            
                            if (bytesRead == 0)
                                break;
            
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
