    private void customMessageBox()
    {
        // custom message box code
        // use NavigationService.GoBack() if you need to exit
    }
    protected override void OnBackKeyPress(CancelEventArgs e)
    {
        e.Cancel = true;
        Deployment.Current.Dispatcher.BeginInvoke(() => customMessageBox() );
    }
