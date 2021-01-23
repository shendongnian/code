    private ManualResetEventSlim _block = new ManualResetEventSlim();
    
    public void A()
    {
        for (int i; i < args.length; i++) 
        {
           _block.Wait(); //This code blocks till UnblockA() is called.
    
           // Do something
        }
    }
    
    public void UnblockA()
    {
        _block.Set();
    }
    
    public void BlockA()
    {
        _block.Reset();
    }
