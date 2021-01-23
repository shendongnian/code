    private async void GoToMyButton()
    {
        if (canExecuteMyButton)
        {
            canExecuteMyButton = false;
            CommandManager.InvalidateRequerySuggested();
            await _navigation.ShowMyButton();
            canExecuteMyButton = true;
            CommandManager.InvalidateRequerySuggested();
        }
    }
