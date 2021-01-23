     using (var webClient = new WebClient())
     {
                        //  Obtain the 'Proxy' of the  Default browser.
                        IWebProxy webProxy = webClient.Proxy;
                        if (webProxy != null)
                        {
                            // Use the default credentials of the logged on user.
                            webProxy.Credentials = CredentialCache.DefaultCredentials;
                        }
                       //do stuff
    }
