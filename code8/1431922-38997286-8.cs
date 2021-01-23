    private void Initialize()
    {
        _stream.Seek(0, SeekOrigin.Begin);
    
        this.InitializePBFReader();
    }
