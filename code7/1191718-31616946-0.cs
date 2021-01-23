    private void SpawnServer()
    { 
        PipeSecurity pipeSa = new PipeSecurity();
        // let everyone read from the pipe but not write to it
        // this was my use case - others may be different
        pipeSa.SetAccessRule(new PipeAccessRule("Everyone", PipeAccessRights.Read, System.Security.AccessControl.AccessControlType.Allow));
        pipeSa.SetAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null), PipeAccessRights.Read, System.Security.AccessControl.AccessControlType.Allow));
        pipeSa.SetAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null), PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow));            
        pipeSa.SetAccessRule(new PipeAccessRule(new SecurityIdentifier(WellKnownSidType.ServiceSid, null), PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));
        pipeSa.SetAccessRule(new PipeAccessRule(WindowsIdentity.GetCurrent().Owner, PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow));            
        var pipeInstance = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 128, PipeTransmissionMode.Byte, PipeOptions.Asynchronous | PipeOptions.WriteThrough, 128, 128, pipeSa);
        PipeClient pipeClient = new PipeClient(pipeInstance, Interlocked.Increment(ref _totalclients));
        pipeInstance.BeginWaitForConnection(HandlePipeConnection, Tuple.Create(pipeInstance, pipeClient));
    }
    // this method asynchronously handles a new pipe connection and starts
    // another server to handle other incoming connections
    private void HandlePipeConnection(IAsyncResult ar)
    {
        var pipeServer = (ar.AsyncState as Tuple<NamedPipeServerStream, PipeClient>).Item1;
        var pipeClient = (ar.AsyncState as Tuple<NamedPipeServerStream, PipeClient>).Item2;
        try
        {
            pipeServer.EndWaitForConnection(ar);
                
            // not shown here, I had the server
            //   send the new client a message upon connect    
            // if (!pipeClient.SendMessage(announceMessage))
            //      throw new Exception("Send message failed for new pipe client connection!");
            pipeClient.Error += PipeClient_Error;
            pipeClient.Disposed += PipeClient_Disposed;
            pipeClient.MessagesReceived += PipeClient_MessagesReceived;
                 
            pipeClient.Read();
        }
        catch (Exception exc)
        {                   
            // Log Exception
            pipeClient.Dispose();
        }
        try
        {
            SpawnServer();
        }
        catch (IOException)
        {
           // if an IO error occurs, most likely it's because max pipe clients reached..
           // in my case I was raising an event here
        }
        catch (Exception exc)
        {
           // otherwise handle the error here (raise another event - not shown..)
        }
    }
