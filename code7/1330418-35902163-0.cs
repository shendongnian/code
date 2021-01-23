    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Program().Run().Wait();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.Read();
        }
        private async Task Run()
        {
            var privatekey = "private key";
            var accountEmailAddress = "email address";
            var credentials = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(accountEmailAddress)
                {
                    Scopes = new[] { AnalyticsService.Scope.AnalyticsReadonly }
                }.FromPrivateKey(privatekey));
            var service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials,
                ApplicationName = "Test"
            });
            var request = new BatchRequest(service);
            BatchRequest.OnResponse<GaData> callback = (content, error, i, message) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error: {0}", error.Message);
                }
                else
                {
                    if (content.Rows != null)
                    {
                        foreach (var item in content.Rows)
                        {
                            foreach (var item1 in item)
                            {
                                Console.WriteLine(item1);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Found");
                    }
                }
            };
            int counter = 0;
            while (counter < 5)
            {
                var req = service.Data.Ga.Get("ga:XXXXX", "30daysAgo", "yesterday", "ga:sessions");
                req.Filters = "ga:pagePath==/page" + counter + ".html";
                request.Queue<GaData>(req, callback);
                counter++;
            }
            await request.ExecuteAsync();
        }
    }
