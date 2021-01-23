    List<Task> _workers = new List<Task>();
    CancellationTokenSource _cts = new CancellationTokenSource();
    
    protected override void OnStart(string[] args)
    {
      for (int i = 0; i < _MAX_WORKERS; i++)
      {
        _workers.Add(RunWorkerAsync(_cts.Token)); 
      }
    }
    public async Task RunWorkerAsync(CancellationToken token)
    {
      while(true)
      {
        token.ThrowIfCancellationRequested();
        // .. get message from amazon sqs sync.. about 20ms
        var message = await sqsClient.ReceiveMessageAsync().ConfigureAwait(false);
    
        try
        {
           await PerformWebRequestAsync(message);
           await InsertIntoDbAsync(message);
        }
        catch(SomeExeception)
        {
           // ... log
           //continue to retry
           continue;
        }
        sqsClient.DeleteMessage();
      }
    }
