    private async void SendButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DataWriter writer = new DataWriter(connectedSocket.OutputStream);
            writer.WriteBytes(Encoding.UTF8.GetBytes(SendMessageTextBox.Text));
            SendMessageTextBox.Text = "";
            await writer.StoreAsync();
            writer.DetachStream();
            writer.Dispose();
        }
        catch(Exception exception)
        {
            rootPage.NotifyUser(exception.Message, NotifyType.ErrorMessage);
        }
    }
 
