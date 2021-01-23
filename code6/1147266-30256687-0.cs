    private async void SendBtn_Click(object sender, RoutedEventArgs e)
    {
        EmailMessage email = new EmailMessage { Subject = "Sending test file" };
        email.To.Add(new EmailRecipient("myMailbox@mail.com"));
        // Create a sample file to send
        StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("testFile.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
        await FileIO.WriteTextAsync(file, "Something inside a file");
        email.Attachments.Add(new EmailAttachment(file.Name, file)); // add attachment
        await EmailManager.ShowComposeNewEmailAsync(email); // send email
    }
