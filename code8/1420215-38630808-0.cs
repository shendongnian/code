    private void globalChatMessageReceived(object sender, TwitchChatClient.OnMessageReceivedArgs e)
    {
        var dispatcher = Application.Current.MainWindow.Dispatcher;
        // Or use this.Dispatcher if this method is in a window class.
        dispatcher.BeginInvoke(new Action(() =>
        {
            richTextBox1.Text = String.Format("#{0} {1}[isSub: {2}]: {3}", e.ChatMessage.Channel, e.ChatMessage.DisplayName, e.ChatMessage.Subscriber, e.ChatMessage.Message) + 
                "\n" + richTextBox1.Text;
        });
    }
