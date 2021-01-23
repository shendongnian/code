    static void Listeners()
        {
            Socket socketForClient = tcpListener.AcceptSocket();
            if (socketForClient.Connected)
            {
                NetworkStream networkStream = new NetworkStream(socketForClient);
                while (true)
                {                                
                    List<int> variables = new List<int>();
                   
                    //Hint : This Line
                    using (var reader = new BinaryReader(networkStream, Encoding.Default, true))
                    {
                        int messageSource = reader.ReadInt32();
                        int messageDesitination = reader.ReadInt32();
                        int interlockingId = reader.ReadInt32();
                        int trackId = reader.ReadInt32();
                        int trainId = reader.ReadInt32();
                        int direction = reader.ReadInt32();
                        int messageType =reader.ReadInt32();
                        int informationType = reader.ReadInt32();
                        int dateTime = reader.ReadInt32();
                         reader.Close();
                    }
            }
         }
