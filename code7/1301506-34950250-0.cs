    void ShowError(String message, Window windowToBlock)  //I call this function in another thread
    {
        if (this.Dispatcher.CheckAccess())
            MessageBox.Show(windowToBlock, message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        else
        {
            this.Dispatcher.Invoke(
                new Action(() =>
                {
                    MessageBox.Show(windowToBlock, message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }));
        }
    }
