    byte[] assembly_bytes;
    
    using (FileStream file = new FileStream(@"someassembly.dll",FileMode.Open,FileAccess.Read,FileShare.None))
    {
        assembly_bytes = new byte[file.Length];
        file.Read(assembly_bytes,0,assembly_bytes.Length);
    }
    
    Assembly assembly = Assembly.Load(assembly_bytes);
