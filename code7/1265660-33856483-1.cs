    private void Method(CancellationToken token)
    {
        foreach (var item in this)
        {
            if (!token.IsCancellationRequested)
            {
                // do my stuss
    
                Task.Delay(1000, token).Wait(); // use await for async method
            }
            else break; // end
        }
    }
