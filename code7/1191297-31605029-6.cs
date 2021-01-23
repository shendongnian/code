    void Main()
    {
        MyStruct ms;
        using (ms = new MyStruct())
        {
            InnerAction(ms);
        }
        
        ms.IsDisposed.Dump();
        _naughtyCachedStruct.IsDisposed.Dump();
    }
    
    MyStruct _naughtyCachedStruct;
    
    void InnerAction(MyStruct s)
    {
        _naughtyCachedStruct = s;
    }
    
    struct MyStruct : IDisposable
    {
        public Boolean IsDisposed { get; set; }
        
        public void Dispose()
        {
            IsDisposed = true;
        }
    }
