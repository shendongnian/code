    using (var client = new SmtpClient ()) {
       client.Connect ("smtp.gmail.com", 587);
    
       // use the OAuth2.0 access token obtained above as the password
       client.Authenticate ("mymail@gmail.com", credential.Token.AccessToken);
    
       client.Send (message);
       client.Disconnect (true);
    }
