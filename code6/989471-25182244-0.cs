    public void DoSomething(Func<Stream> streamFactory)
    {
        using(var stream = streamFactory())
        using(var reader = new StreamReader(..))
        {
            ...
        }
    }
