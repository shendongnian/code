    RelayCommand(i => this.ClickMe(), null);
    private void ClickMe()
    {
        MessageBox.Show("ClickMe!");
    }
    private bool CanClick()
    {
        // logic that allows the command to be executed
    }
    
