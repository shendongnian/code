    public void SendSMTPMail(string from, string to, string subject, string body)
    {
        var message = new MimeMessage ();
        var builder = new BodyBuilder ();
    
        message.From.Add (InternetAddress.Parse (from));
        message.To.Add (InternetAddress.Parse (to));
        message.Subject = subject;
    
        builder.TextBody = body;
    
        message.Body = builder.ToMessageBody ();
    
        using (var client = new SmtpClient ()) {
            client.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
    
            client.Connect ("mail.mydomain.gr", 25, false);
            client.Authenticate ("noreply@mydomain.gr", "mypass");
            client.Send (message);
            client.Disconnect (true);
        }
    }
