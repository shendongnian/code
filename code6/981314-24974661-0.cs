    public static readonly DependencyProperty Command1Property = 
        DependencyProperty.Register(
        "Command1", typeof(ICommand),
        typeof(MyUserControl), null
        );
    public ICommand Command1
    {
        get { return (ICommand)GetValue(Command1Property); }
        set { SetValue(Command1Property, value); }
    }
