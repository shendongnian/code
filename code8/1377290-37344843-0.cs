            public static void StartClient()
            {
                byte[] msg;
                try
                {
                    string inputFile = @"C:\TCPIP\test_big.iso";
                    IPAddress ipAd = IPAddress.Parse("192.168.137.71");
                    IPEndPoint remoteEP = new IPEndPoint(ipAd, 1234);
                    Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sender.Connect(remoteEP);
    
                    Console.WriteLine("Client connected to {0}", sender.RemoteEndPoint.ToString());
                    Console.WriteLine("Sending file...");
    
                    //8 bytes, file lenght info, TCP Header
    
                   
                    long length = new System.IO.FileInfo(inputFile).Length;
                    byte[] fileLenght = BitConverter.GetBytes(length);
                    
                    //1 byte, file extension info, TCP Header
                    byte extension = 2; //file extension code
                    byte[] newArray = new byte[fileLenght.Length + 1];
                    fileLenght.CopyTo(newArray, 1);
                    newArray[0] = extension;
                    fileLenght = newArray;
    
                    //send TCP Header
                    int bytesSent = sender.Send(fileLenght);
    
                    //send file in chunks
                    int chunkSize = 1024;
                    byte[] chunk = new byte[chunkSize];
                    int SendPackage;
                    using (FileStream fileReader = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader binaryReader = new BinaryReader(fileReader);
                        int bytesToRead = (int)fileReader.Length;
                        do
                        {
                            chunk = binaryReader.ReadBytes(chunkSize);
                            bytesToRead -= chunkSize;
                            SendPackage = sender.Send(chunk);
                        } while (bytesToRead > 0);
    
                    binaryReader.Close();
                    }
    
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
    
                    Console.WriteLine("\nPress ENTER to continue...");
                    Console.Read();
    
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
