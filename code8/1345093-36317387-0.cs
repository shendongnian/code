       NamedPipeServerStream serverStream =
            new NamedPipeServerStream(
                "bobasdfpipe",
                PipeDirection.InOut,
                254,
                PipeTransmissionMode.Message,
                PipeOptions.Asynchronous);
       
        IAsyncResult connectionResult = null;
        try {  
                serverStream.BeginWaitForConnection(
                    this.HandleConnection,
                    serverStream);
         }
        catch(IOException)
        {
           // Connection has been unexpectedly closed by client...
           continue;
        }
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
                try
                {
                   serverStream.EndWaitForConnection(connectionResult);
                }
                catch(IOException)
                {
                    // Connection has been unexpectedly closed by client...
                }  
                break;
        }
