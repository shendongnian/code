    void Example()
    {
        SmtpClient client1 = new SmtpClient(emailsrvr, emailport);
        client1.SendCompleted += OnSendCompleted;
        SmtpClient client2 = new SmtpClient(emailsrvr, emailport);
        client2.SendCompleted += OnSendCompleted;
        MailMessage message1 = //...
        MailMessage message2 = //...
        client1.SendAsync(message1, "1");
        client2.SendAsync(message1, "2");
    }
    
    void OnSendCompleted(object sender, AsyncCompletedEventArgs args)
    {
        Console.WriteLine("Message {0} sent!", args.UserState);
    }
    
    //Prints out:
    //Message 1 sent!
    //Message 2 sent!
