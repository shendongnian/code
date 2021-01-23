    void PrintMe(IFormattable message)
    {
        Console.WriteLine("I am a " + message.GetType().FullName);
    }
    
    PrintMe($"{ "Hello World"}");
