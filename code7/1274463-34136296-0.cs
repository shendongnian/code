    CancellationTokenSource cts = new CancellationTokenSource();
    Task T = Class.Initialize(cts.Token);
    if (T.IsCancelled){ /*Do Stuff Here*/ }
    
    private static async Task Initializ(CancellationToken token ) 
    {
      /*Do Stuff Here*/ 
      token.ThrowIfCancellationRequested();
      /*Do More Stuff Here*/ 
    }
