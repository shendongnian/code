    public List<Object> ReadWriteArgs { get; set; }
    public bool ConfirmRWArgs(List<Type> types)
    {
        for (int i = 0; i < types.Count; i++)
        {
            if (ReadWriteArgs[i].GetType() != types[i])
                return false;
        }
    
        return true;
    }
