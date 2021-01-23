    void Example()
    {
        SmtpClient client = new SmtpClient(emailsrvr, emailport);
        client.SendCompleted += OnSendCompleted;
    
        MailMessage message1 = //...
        MailMessage message2 = //...
        client.SendAsync(message1, "1");
        client.SendAsync(message1, "2");
    }
    
    void OnSendCompleted(object sender, AsyncCompletedEventArgs args)
    {
        Console.WriteLine("Message {0} sent!", args.UserState);
    }
    
    //Prints out:
    //Message 1 sent!
    //Message 2 sent!
