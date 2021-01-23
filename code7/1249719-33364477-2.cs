     using Google.Apis.Auth.OAuth2;
    using Google.Apis.Util.Store;
    using Google.Contacts;
    using Google.GData.Client;
    using System;
    using System.Threading;
    public static void auth()
    {
        string clientId = "xxxxxx.apps.googleusercontent.com";
        string clientSecret = "xxxxx";
        string[] scopes = new string[] { "https://www.googleapis.com/auth/contacts.readonly" };     // view your basic profile info.
        try
        {
            // Use the current Google .net client library to get the Oauth2 stuff.
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                         , scopes
                                                                                         , "test"
                                                                                         , CancellationToken.None
                                                                                         , new FileDataStore("test")).Result;
            // Translate the Oauth permissions to something the old client libray can read
            OAuth2Parameters parameters = new OAuth2Parameters();
            parameters.AccessToken = credential.Token.AccessToken;
            parameters.RefreshToken = credential.Token.RefreshToken;
            RunContactsSample(parameters);
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.ReadLine();
        }
        Console.ReadLine();
    }
    /// <summary> 
    /// Send authorized queries to a Request-based library 
    /// </summary> 
    /// <param name="service"></param> 
    private static void RunContactsSample(OAuth2Parameters parameters)
    {
        try
        {
            RequestSettings settings = new RequestSettings("Google contacts tutorial", parameters);
            ContactsRequest cr = new ContactsRequest(settings);
            Feed<Contact> f = cr.GetContacts();
            foreach (Contact c in f.Entries)
            {
                Console.WriteLine(c.Name.FullName);
            }
        }
        catch (Exception a)
        {
            Console.WriteLine("A Google Apps error occurred.");
            Console.WriteLine();
        }
    }
