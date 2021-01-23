    public void Execute(IFoo input)
    {
        // do process...
 
        IDisposable disposable = input as IDisposable;
        if (disposable != null)
        {
            disposable.Dispose();
        }
    }
 
