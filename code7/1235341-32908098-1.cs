    private void Poll()
    {
        CancellationTokenSource source = new CancellationTokenSource();
        TimeSpan interval = TimeSpan.Zero;
    
        while (!source.Token.WaitHandle.WaitOne(interval))
        {
            using (IImapClient emailClient = new S22ImapClient())
            {
                ImapClientSettings chatSettings = ...;
                
                var task = Task.Run(() => 
                {
                    source.CancelAfter(TimeSpan.FromSeconds(5));
                    emailClient.Connect(chatSettings); // CAN SOMETIMES HANG HERE                   
                }, source.Token);
    
                // SOME WORK DONE HERE
            }
    
            interval = this._waitAfterSuccessInterval;
    
            // check the cancellation state.
            if (source.IsCancellationRequested)
            {
                break;
            }
        }
    }
