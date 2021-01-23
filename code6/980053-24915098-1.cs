    private async void customMessageBox()
    {
        // custom message box code
    }
    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        e.Cancel = true;
        await customMessageBox();
    }
    
