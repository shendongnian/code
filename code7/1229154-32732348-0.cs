    public bool CopyTest()
    {
       return this == Copy();
    }
    
    public object Copy() 
    {
       return SerializeService.DeserializeFromStream(SerializeService.SerializeToStream(this));
    }
