    class Program
    {
        static void Main(string[] args)
        {
            var authContext = new AuthenticationContext(Constants.AUTHORITY);
            var credential = 
                new ClientCredential(Constants.CLIENT_ID, Constants.CLIENT_SECRET);
            var result = (AuthenticationResult)authContext
                .AcquireTokenAsync(Constants.API_ID_URL, credential)
                .Result;
            var token = result.AccessToken;
            Console.WriteLine(token.ToString());
            Console.ReadLine();
        }
    }
