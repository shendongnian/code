    public List<Object> ReadWriteArgs { get; set; }
    public bool ConfirmRWArgs(int count, List<Type> types)
    {
        return ReadWriteArgs != null
               && ReadWriteArgs.Count == count
               && ReadWriteArgs.Zip(types, (arg, type) => arg.GetType() == type).All(b => b);
    }
