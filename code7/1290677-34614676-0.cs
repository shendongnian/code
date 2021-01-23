            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                SendCommand("QUIT", "closing connection");
                _reader.ReadLine();
                //TODO : verify the response code received
                client.Close();
            };
