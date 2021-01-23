       using (var client = new Pop3Client()) {
     // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS) 
     client.ServerCertificateValidationCallback = (s, c, h, e) => true; 
     client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
     client.Connect("pop.gmail.com", "995", true);
     client.AuthenticationMechanisms.Remove("XOAUTH2"); 
     client.Authenticate(MailUsername, MailPassword);
    ..
    ....
    ......
    }
