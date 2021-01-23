    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tokens = new Twitterizer.OAuthTokens
                {
                    ConsumerKey = @"",
                    ConsumerSecret = @"",
                    AccessToken = @"-",
                    AccessTokenSecret = @""
                };
    
                var response = Twitterizer.TwitterSearch.Search(tokens, " ",
                  new Twitterizer.SearchOptions
                  {
                      Count = 5,
                      GeoCode = "39.920687,32.853970,50km"
                  });
                if (response.Result != Twitterizer.RequestResult.Success)
                    return;
                var index = 0;
                foreach (var status in response.ResponseObject)
                {
                    index++;
                    Console.WriteLine(index);
                    Console.WriteLine(status.Text);
                    Console.WriteLine(status.CreatedDate);
                    
                    
                }
    
                Console.ReadLine();
            }
        }
    }
