    using (var client = new SmtpClient()) {
        // Note: don't set a timeout unless you REALLY know what you are doing.
        //client.Timeout = 1000 * 20;
        // Removing this here won't do anything because the AuthenticationMechanisms
        // do not get populated until the client connects to the server.
        //client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
        client.Connect ("smtp.mail.me.com", 587, SecureSocketOptions.StartTLS);
    
        client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
        client.Authenticate (username, password);
        client.Send (message);
    }
