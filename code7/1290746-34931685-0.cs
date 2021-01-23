    public Predicate<string> IsNullOrWhiteSpace = string.IsNullOrWhiteSpace;
    
    public void F(string x)
    {
	    Contract.Requires(!IsNullOrWhiteSpace(x));
    
	    throw new NotImplementedException();
    }
