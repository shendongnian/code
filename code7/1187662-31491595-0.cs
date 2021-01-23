    public void ProcessCompleteCallback()
    {
        MessageBox.Show("Process completed.");
        Application.Current.Dispatcher.Invoke(() => 
        {
            GenerateOutputButton.IsEnabled = true;
            LoadingGifImage.Visibility = Visibility.Hidden;
            CommandManager.InvalidateRequerySuggested();
        });
    }
