    private async void SendEmailButton_Click(object sender, RoutedEventArgs e)
    {
    EmailMessage emailMessage = new EmailMessage();
    emailMessage.To.Add(new EmailRecipient("***@***.com"));
    string messageBody = "Hello World";
    emailMessage.Body = messageBody;
    await EmailManager.ShowComposeNewEmailAsync(emailMessage);
    }
