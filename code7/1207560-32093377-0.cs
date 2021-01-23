    // You should use a using statement
    using (SmtpClient client = new SmtpClient("<smtp-server-address>", 25))
    {
       // Configure the client
       client.EnableSsl = true;
       client.Credentials = new NetworkCredential("<username>", "<password>");
       // client.UseDefaultCredentials = true;
    
       // A client has been created, now you need to create a MailMessage object
       MailMessage message = new MailMessage(
                                "from@example.com", // From field
                                "to@example.com", // Recipient field
                                "Hello", // Subject of the email message
                                "World!" // Email message body
                             );
    
       // Send the message
       client.Send(message);
    
       /* 
        * Since I was using Console app, that is why I am able to use the Console
        * object, your framework would have different ones. 
        * There is actually no need for these following lines, you can ignore them
        * if you want to. SMTP protocol would still send the email of yours. */
        
       // Print a notification message
       Console.WriteLine("Email has been sent.");
       // Just for the sake of pausing the application
       Console.Read();
    }
