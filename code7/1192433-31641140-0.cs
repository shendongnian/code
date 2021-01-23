    public ICommand CommandToExecute
    {
        get { return (ICommand)GetValue(CommandToExecuteProperty); }
        set { SetValue(CommandToExecuteProperty, value); }
    }
    public static readonly DependencyProperty CommandToExecuteProperty =
            DependencyProperty.Register("CommandToExecute", typeof(ICommand), typeof(EventToCommandTrigger), new FrameworkPropertyMetadata(null));
