    private void DoSomething(object source, EventArgs eventArgs)
    {
        Console.WriteLine("Something happened.");
    }
    private void DoSomethingElse(object source, EventArgs eventArgs)
    {
        Console.WriteLine("Something else happened.");
    }
    private void AttachToEvent()
    {
        button1.Clicked += DoSomething;
        button1.Clicked += DoSomethingElse;
        button1.Clicked += DoSomething;
    }
