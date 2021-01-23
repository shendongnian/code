    public void SomeMethod(string someParameter)
    {
        Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(someParameter));
    }
    
