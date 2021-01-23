        public WindowsFormsServer()
        {
            var frameTask = Task.Factory.StartNew(() =>
            {
                try
                {
                    while (true) 
                    {
                            if (WindowsFormsServer.y == 0)
                            {
                                WindowsFormsServer.server = WindowsFormsServer.Idea_server();
                                // WindowsFormsServer.server.ReceiveTimeout = 50000;
                                //          Console.WriteLine("Waiting for a connection...");
                                WindowsFormsServer.streamserver = server.GetStream();
                            }
                            //streamserver.Flush();
                            
                            byte[] responseBytes = null;
                            
                            //if (streamserver.CanRead)
                            //{
                                var responseStream = new System.IO.MemoryStream();
                                byte[] sizePacket = new byte[4];
                                var br = new BinaryReader(streamserver);
                                var length = br.ReadUInt32();
                                var responseLength = br.ReadBytes(4);
                                int responseIntLength = BitConverter.ToInt32(responseLength, 0);
                                byte[] response = new byte[responseIntLength];
                                System.Console.WriteLine("size inside responseIntLength = " + responseLength);
                                int bytesReceived = 0;
                                while (bytesReceived < responseIntLength)
                                {
                                    int bytesRead = streamserver.Read(response, bytesReceived, responseIntLength - bytesReceived);
                                    bytesReceived += bytesRead;
                                }
                                System.Console.WriteLine("frameTask attivo \r\n");
                                responseStream.Write(response, 0, responseIntLength);
                                //System.Threading.Thread.Sleep(1); //added this line
                                responseBytes = responseStream.ToArray();
                                Console.WriteLine("responseBytes Length = " + responseBytes.Length);
                            //}
                    }
                }
                catch (NullReferenceException ex) 
                { 
                    System.Console.WriteLine("Errore: " + ex.ToString()); 
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                try
                {
                    //MessageData.Picture2 = (Bitmap)byteArrayToImage(Compressor.Compressor.Decompress(responseBytes));
                    MessageData.Picture2 = (Bitmap)byteArrayToImage(responseBytes);
                    CamImageBox.Image = MessageData.Picture2;
                }
                catch (NullReferenceException ex)
                {
                    System.Console.WriteLine("Errore: " + ex.ToString());
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Errore: " + ex.ToString());
                }
            });
            //frameTask.Start();
            InitializeComponent();
        }
