    byte[] assembly_bytes;
    
    using (var file = new FileStream(
        @"..\..\anexternallibrary.dll",
        FileMode.Open,
        FileAccess.Read,
        FileShare.None))
    {
        assembly_bytes = new byte[file.Length];
        file.Read(assembly_bytes,0,assembly_bytes.Length);
    }
    
    Assembly assembly = Assembly.Load(assembly_bytes);
