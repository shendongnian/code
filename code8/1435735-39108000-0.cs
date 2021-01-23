    [Flags]
    public enum Permission
    {
        Read1 = 0x00000001,
        Read2 = 0x00000002,
        Read3 = 0x00000004,
    
        Write1 = 0x00000008,
        Write2 = 0x00000010,
        Write3 = 0x00000020,
    
        Update1 = 0x00000040,
        Update2 = 0x00000080,
        Update3 = 0x00000100,
    
        Destory = 0x00000400,
    
        Other = 0x00000800,
    
        SomethingElse = 0x00001000,
    
    }
