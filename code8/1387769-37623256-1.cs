        var shouldRun = true;
        while(shouldRun)
        {
            try 
            {
                  string receivedDataString = null;
                  listenSock.Listen(3);
                  acceptedSock = listenSock.Accept();
                  listenSock.Bind(new IPEndPoint(IPAddress.Any, 5665));
        
                 while (listenSock.SendBufferSize != 0)
                 { 
                         ...
                 }
            }
            catch
            {
            }
        }
