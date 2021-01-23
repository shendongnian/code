    void bw_RunWorkerConnectCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            MessageBoxButton btn = MessageBoxButton.OK;
            ModernDialog.ShowMessage(e.Error.Message, "Failure to connect", btn);
            return;
        }
    
        ConnectProgressRing.Visibility = Visibility.Hidden;
        btnLogin.Visibility = Visibility.Visible;
    }
