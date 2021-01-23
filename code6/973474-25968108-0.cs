    public void Send(string SendStr, string PipeName, int TimeOut = 1000)
    {
        try
        {
            NamedPipeClientStream pipeStream = new NamedPipeClientStream
              (".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous);
            // The connect function will indefinitely wait for the pipe to become available
            // If that is not acceptable specify a maximum waiting time (in ms)
            pipeStream.Connect(TimeOut); 
            int _serverCount = pipeStream1.NumberOfServerInstances; 
            byte[] _buffer = Encoding.UTF8.GetBytes(SendStr);
            pipeStream.BeginWrite(_buffer, 0, _buffer.Length, new AsyncCallback(AsyncSend), pipeStream);
            //there is more than 1 server present
            for (int i = 1; i < _serverCount; i++)
                {
                    //create another client copy and use it
                    NamedPipeClientStream pipeStream2 = new NamedPipeClientStream
                    (".", PipeName, PipeDirection.Out, PipeOptions.Asynchronous);
                    pipeStream2.Connect(TimeOut);
                    byte[] buffer2 = Encoding.UTF8.GetBytes(SendStr);
                    pipeStream2.BeginWrite(buffer2, 0, buffer2.Length, AsyncSend, pipeStream2);
                }
        }
        catch (TimeoutException oEX)
        {    ...        }
    }
