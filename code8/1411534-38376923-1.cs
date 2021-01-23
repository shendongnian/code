            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 3998);
            sender.Connect(remoteEP);
            using (var networkStream = new NetworkStream(sender))
            {
                // Some byte operations there: adding headers, file description and other stuff.
                // These should sent here by virtue of writing bytes (array) to the networkStream
                // Then send your file
                using (var fileStream = File.Open(@"С:\img.bmp", FileMode.Open))
                {
                    // .NET 4.0+
                    fileStream.CopyTo(networkStream);
                    // older .NET versions
                    /*
                    byte[] buffer = new byte[4096];
                    int read;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                        networkStream.Write(buffer, 0, read);
                    */
                }
            }
