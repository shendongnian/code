    public TResult[] Execute<TResult>()
    {
        var myArray = ... 
        return myArray.Cast<TResult>().ToArray();
    }
