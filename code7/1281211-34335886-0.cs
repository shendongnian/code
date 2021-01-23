    private bool hasBeenDisposed ; 
    
    public void Dispose() 
    {
        if (!hasBeenDisposed)
        {
            DisposeInstance(inst1, inst2, inst3);
            hasBeenDisposed = true ; 
        }
    }
