    public IEnumerable<Type> GetAllTypesInDll(string filename)
    {
        // load assembly from file
        Assembly asm = Assembly.LoadFile(filename);
    
        // enumerate all types
        return asm.GetTypes();
    }
