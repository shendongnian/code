    Lazy<int> lazyResult = new Lazy<int>(GetComputationResult);
    public int Result { get { return lazyResult.Value; } }
    public void Reset()
    {
       lazyResult = new Lazy<int>(GetComputationResult);
    }
