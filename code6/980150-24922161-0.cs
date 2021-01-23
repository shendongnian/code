    class Program
    {
        // These come from the APIs console:
        //   https://code.google.com/apis/console
        public static ClientSecrets secrets = new ClientSecrets()
        {
            ClientId = "YOUR_CLIENT_ID",
            ClientSecret = "YOUR_CLIENT_SECRET"
        };
        static void Main(string[] args)
        {
            Console.WriteLine(@"Starting authorization...");
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets,
                new[] { PlusService.Scope.PlusLogin },
                "me",
                CancellationToken.None).Result;
            // Create the service.
            var plusService = new PlusService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Console Google+ Demo",
            });
            Person me = plusService.People.Get("me").Execute();
            Console.Write(@"Authorized user: " + me.DisplayName + "\n");
            Console.Write(@"Press enter to exit.");
            Console.Read();
        }
    }
