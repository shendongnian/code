    using System;
    using System.Windows.Forms;
    using Google.GData.Client;
    using Google.GData.Spreadsheets;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                string CLIENT_ID = "YOUR_CLIENT_ID";
                string CLIENT_SECRET = "YOUR_CLIENT_SECRET";
                string SCOPE = "https://spreadsheets.google.com/feeds https://docs.google.com/feeds";
                string REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";
    
                OAuth2Parameters parameters = new OAuth2Parameters();
    
                parameters.ClientId = CLIENT_ID;
                parameters.ClientSecret = CLIENT_SECRET;
                parameters.RedirectUri = REDIRECT_URI;
                parameters.Scope = SCOPE;
    
                string authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
                MessageBox.Show(authorizationUrl);
                Console.WriteLine("Please visit the URL in the message box to authorize your OAuth "
                  + "request token.  Once that is complete, type in your access code to "
                  + "continue...");
                parameters.AccessCode = Console.ReadLine();
    
                OAuthUtil.GetAccessToken(parameters);
                string accessToken = parameters.AccessToken;
                Console.WriteLine("OAuth Access Token: " + accessToken);
    
                GOAuth2RequestFactory requestFactory =
                    new GOAuth2RequestFactory(null, "MySpreadsheetIntegration-v1", parameters);
                SpreadsheetsService service = new SpreadsheetsService("MySpreadsheetIntegration-v1");
                service.RequestFactory = requestFactory;
    
                SpreadsheetQuery query = new SpreadsheetQuery();
    
                SpreadsheetFeed feed = service.Query(query);
    
                // Iterate through all of the spreadsheets returned
                foreach (SpreadsheetEntry entry in feed.Entries)
                {
                    // Print the title of this spreadsheet to the screen
                    Console.WriteLine(entry.Title.Text);
                }
                Console.ReadLine();
            }
        }
    }
