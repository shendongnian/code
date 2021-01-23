    foreach(..)
    {
        string value = content.ToString();
        Dispatcher.Invoke(updateTextDelegate, DispatcherPriority.Background, new object[] { TextBox.TextProperty,  value });
    }
