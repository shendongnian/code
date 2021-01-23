    public MvxCommand ItemClickCommand { get; }
    public MyClass()
    {
        ItemClickCommand = MvxCommand(ExecuteItemClickCommand);
    }
