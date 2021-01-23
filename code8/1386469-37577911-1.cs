    public delegate void PrintedSomethingEventHandler(string message);
    public event PrintedSomethingEventHandler PrintedSomething;
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
        if(debug)
            action = PrintA;
        else
            action = PrintB;
        action(message);
        if(PrintedSomethingEventHandler != null)
            PrintedSomethingEventHandler(message);
    }
   
