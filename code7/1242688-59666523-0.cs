    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        ICommand command = null;
        switch (e.Key)
        {
            case Key.A:
                command = Commands.SomeCommand;
                break;
            case Key.B:
                command = Commands.SomeOtherCommand;
                break;
        }
        bool isSourceATextBox = e.InputSource.GetType() == typeof(TextBox);
        if (command != null && !isSourceATextBox)
        {
            command.Execute(parameter:null);
        }
    }
