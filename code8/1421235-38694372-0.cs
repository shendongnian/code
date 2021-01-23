    // Only if the Popup is shown
    if (isShowingBackendServerMessageBox)
    {
        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        {
            // Get the frontmost Window
            var messageBox = Application.Current.Windows
                ?.OfType<BackendServerCheckMessageBox>()
                ?.FirstOrDefault();
    
            // If it is the searched MessageBox, reload all Bindings.
            if (messageBox != null)
            {
                messageBox.DataContext = null;
                messageBox.DataContext = this;
            }
        }));
    }
