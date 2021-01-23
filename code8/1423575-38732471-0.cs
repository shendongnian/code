    public async Task UpdateMessageBox()
    {
        messageTextBox.Text += "Reading data from serial.";
        while (_serialConnected)
        {
            string message = await SerialReadLineAsync(serial).ConfigureAwait(true);
            messageTextBox.Text += message;
        }
    }
