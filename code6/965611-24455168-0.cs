    static void Listeners()
        {
            Socket socketForClient = tcpListener.AcceptSocket();
            if (socketForClient.Connected)
            {
                using (var reader = new BinaryReader(new NetworkStream(socketForClient), Encoding.Default, true))
                {
                    while (((int)reader.PeekChar()) != -1)
                    {                                 
                        List<int> variables = new List<int>();
 
                        int messageSource = reader.ReadInt32();
                        int messageDesitination = reader.ReadInt32();
                        int interlockingId = reader.ReadInt32();
                        int trackId = reader.ReadInt32();
                        int trainId = reader.ReadInt32();
                        int direction = reader.ReadInt32();
                        int messageType =reader.ReadInt32();
                        int informationType = reader.ReadInt32();
                        int dateTime = reader.ReadInt32();
                     }
                }
         }
