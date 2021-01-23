    private string _input;
    public string Input
    {
        get { return _input; }
        set
        {
            if (_input != value)
            {
                _input = value;
                CallMethod();
            }
        }
    }
        
    private void CallMethod()
    {
        Console.Write("Input has changed");
    }
    private void ReadFromConsole()
    {
        Input = Console.ReadLine();
    }
      
