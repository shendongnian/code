       NamedPipeServerStream serverStream =
            new NamedPipeServerStream(
                "bobasdfpipe",
                PipeDirection.InOut,
                254,
                PipeTransmissionMode.Message,
                PipeOptions.Asynchronous);
       
        try 
        {  
            IAsyncResult connectionResult = serverStream.BeginWaitForConnection(
                    this.HandleConnection,
                    serverStream);
           int waitResult =
               WaitHandle.WaitAny(
                   new[]
                    {
                        this.ShutdownEvent,
                        connectionResult.AsyncWaitHandle
                    });
            switch (waitResult)
            {
              case 0:
                // this.ShutdownEvent
                shuttingDown = true;
                break;
              case 1:
                // connectionResult.AsyncWaitHandle
                   serverStream.EndWaitForConnection(connectionResult);
                   break;
             }    
        }
        catch(IOException)
        {
            // connection has been terminated by a client
        }
