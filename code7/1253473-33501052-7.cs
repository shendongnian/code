    using (var client = new SmtpClient ()) {
       client.Connect ("smtp.gmail.com", 587);
    
       // use the OAuth2.0 access token obtained above
       var oauth2 = new SaslMechanismOAuth2 ("mymail@gmail.com", credential.Token.AccessToken);
       client.Authenticate (oauth2);
    
       client.Send (message);
       client.Disconnect (true);
    }
