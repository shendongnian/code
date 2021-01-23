    private void Method(CancellationToken token)
    {
        bool contine;
        foreach (var item in this)
        {
            if (contine)
            {
                // do my stuss
    
                Task.Delay(1000, token).Wait(); // use await for async method
            }
            else break; // end
        }
    }
