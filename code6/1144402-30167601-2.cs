    public void Search()
    {
        Find();
    }
    
    protected override async void OnShown(EventArgs e)
    {
       base.OnShown(e);
    
       try
       {
           await Task.Run(() =>
           {
               foreach (var item in results)
               {
                   cts.Token.ThrowIfCancellationRequested();
    			   item.Search();
               }
           }, cts.Token);
       }
       catch (OperationCanceledException)
       { }
    }
