    RemoveItemEventHandler myHandler = (object s, RemoveItemEventArgs args) =>
    {
        StringItem item = args.RemoveItem as StringItem;
        MessageBoxResult result = MessageBox.Show("Are you sure that you would like" + 
            " to permanently remove \"" + item.DisplayName + "\" from the list?",
            "Remove Topping?", 
            MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.No)
        {    //The user cancelled the deletion, so cancel the event as well.
            args.Cancel = true;
        }
    };
    //Subscribe to RemoveItem event.
    dialog.RemoveItem += myHandler;
