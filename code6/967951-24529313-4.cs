    public void MyMethod(params long[] items)
    {
        // call to the previously mentioned extension method
        MyMethod(items.ToEnumerable());
    }
    
    public void MyMethod(IEnumerable<long> items)
    {
        foreach (YourType item in items)
        {
            // Do stuff
        }
    }
