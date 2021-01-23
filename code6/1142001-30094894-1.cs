    DoSomethingCodeA();
    foreach (var x in SomeMethod()) 
    {
        DoSomethingCodeB();  
    }
    DoSomethingCodeC();
    private SomeType SomeMethod()
    {
        try
        {
            get some piece of data from somewhere
            yield return data
        }
        catch (SomeException)
        {
            handle it
        }
    }
