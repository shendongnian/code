     private void ClientConnected(IAsyncResult ar)
        {
            byte[] readBytes = new byte[65536];
            TcpClient client;
            try
            {
                client = listener.EndAcceptTcpClient(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
            try
            {
                NetworkStream stream = client.GetStream();
                stream.BeginRead(buffer, 0, buffer.Length, ReadStream, stream);
                listener.BeginAcceptTcpClient(ClientConnected, listener);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void ReadStream(IAsyncResult ar)
        {
            try
            {
                NetworkStream stream = (NetworkStream)ar.AsyncState;
                int bytesRead = stream.EndRead(ar);
                content += Encoding.ASCII.GetString(buffer, 0, bytesRead);
                dataProcessor.ProcessData(messages);
                stream.BeginRead(buffer, 0, buffer.Length, ReadStream, stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
