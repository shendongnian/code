    void DoSomethingAndNotify(Action<string> notifyCallback)
    {
        // Do something
        ...
        string result = "something was done";
        notifyCallback(result);
    }
    void EmailNotifier(string message)
    {
        // Send message via email
    }
    void ConsoleNotifier(string message)
    {
        Console.WriteLine(message);
    }
