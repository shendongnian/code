    public IEnumerable<int> SomeSequence()
    {
        try
        {
            //do something
        }
        catch
        {
            yield 1; //error
        }
    }
