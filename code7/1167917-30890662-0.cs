          byte[] byteReadStream = null; // holds the data in byte buffer
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any,
                                            3000); //listen on all local addresses and 8888 port
            TcpListener tcpl = new TcpListener(ipe);
       tcpl.Start(); // block application until data and connection
                TcpClient tcpc = tcpl.AcceptTcpClient();
            while (true)
            {
                //infinite loop
         
                byteReadStream = new byte[]; 
                tcpc.GetStream().Receive(byteReadStream);
                Console.WriteLine(Encoding.Default.GetString(byteReadStream)
                                  + "\n")
                    ;
            }
