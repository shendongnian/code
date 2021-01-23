    private event TextChangedHandler TextChanged;
    public delegate void TextChangedHandler();
    private string _input;
    public string Input
    {
        get { return _input; }
        set
        {
            if (_input != value)
            {
                _input = value;
                TextChanged?.Invoke();
            }
        }
    }
    private void CallMethod()
    {
        Console.Write("Input has changed");
    }
    private void ReadFromConsole()
    {
        TextChanged += CallMethod;
        Input = Console.ReadLine();
    }
