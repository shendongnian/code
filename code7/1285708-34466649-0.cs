    void PrintSomething(string stringToPrint) { Console.Write(stringToPrint); }
    void DoSomething(Action methodToCall) { methodToCall(); }
    void Main() 
    { 
        DoSomething(() => PrintSomething("Message")); 
    }
