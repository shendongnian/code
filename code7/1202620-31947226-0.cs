    public List<Object> ReadWriteArgs { get; set; }
    public Booolean ConfirmRWArgs(int count, List<Type> types)
    {
        if(ReadWriteArgs != null && ReadWriteArgs.Count == count)
        {
            // Compare List<Type> to the types of List<Object>
	    if (types.IsGenericType && types.GetGenericTypeDefinition() == typeof(List<>))
        	return true;
        }
        return false;
    }
