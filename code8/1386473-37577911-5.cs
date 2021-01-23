    //EventHandler definition
    public delegate void PrintedSomethingEventHandler(string message);
    //Event
    public event PrintedSomethingEventHandler PrintedSomething;
    //e.g. "Function Hook"
    private Func<string,string> _externalFilter;
    public void SetFilter(Func<string,string> filter)
    {
        _externalFilter = filter;
    }
    private void PrintA(string message)
    {
        Debug.WriteLine(message);
    }
    private void PrintB(string message)
    {
        Console.WriteLine(message);
    }
    private bool ContainsProfanity(string message)
    {
        return message.Contains("%$&!");
    }
    public void Print(string message, bool debug)
    {
        Action<string> action;
        Predicate<string> filter = ContainsProfanity;
        if(filter(message))
            return;
        if(_externalFilter != null)
            message = _externalFilter(message);
        if(debug)
            action = PrintA;
        else
            action = PrintB;
        action(message);
        if(PrintedSomethingEventHandler != null)
            PrintedSomethingEventHandler(message);
    }
   
