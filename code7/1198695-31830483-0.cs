    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP1)
    {
        Credentials = new WebCredentials("usrname", "pass#1234")
    };
    
    //to add logic for itemview
    service.AutodiscoverUrl("emailaddress@test.com", RedirectionUrlValidationCallback);
    private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            var result = false;
            var redirectionUri = new Uri(redirectionUrl);
            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
