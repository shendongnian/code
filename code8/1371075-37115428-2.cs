    private static object lockObject = new object();
    // ...
    
    Command current;
    lock (lockObject)
    {
        current = CommandList;
        CommandList = CommandList.Next;
    }
    // use current.
