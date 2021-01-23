    public void AssertFlag(bool flag)
    {
        if(flag)
        {
             throw new Exception(); //You can use a more specific type
        }
    }
