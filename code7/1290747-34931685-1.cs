    // Workaround for https://github.com/Microsoft/CodeContracts/issues/339
    public Predicate<string> IsNullOrWhiteSpace = string.IsNullOrWhiteSpace;
    
    public void F(string x)
    {
	    Contract.Requires(!IsNullOrWhiteSpace(x));
    
	    throw new NotImplementedException();
    }
