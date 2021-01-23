    if (!MyTextBox.Dispatcher.CheckAccess())
    {
        MyTextBox.Dispatcher.Invoke(() => { MyTextBox.Text = myReceivedMessage.ToString(); });
    }
    else
    {
        MyTextBox.Text = myReceivedMessage.ToString();
    }
