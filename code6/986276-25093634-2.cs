                TcpClient client = server.AcceptTcpClient();
                
                // ...
                
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();
                int i = stream.Read(bytes, 0, bytes.Length);
                while (i != 0)
                {
                    // ...
                    i = stream.Read(bytes, 0, bytes.Length);
                }
