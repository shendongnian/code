    if (typeof(ICommand).IsAssignableFrom(prop.PropertyType))
    {
        ICommand command = (ICommand)prop.GetValue(VM);
        command.CanExecuteChanged += MyHandler;
    }
