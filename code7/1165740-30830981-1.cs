    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Authentication.OAuth2;
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
    
    using Google.Apis.Bigquery.v2;
    using Google.Apis.Bigquery.v2.Data;
    
    using Google.Apis.Util;
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    
    namespace BigQueryConsole
    {
        public class BigQueryConsole
        {
            // Put your client ID and secret here (from https://developers.google.com/console)
            // Use the installed app flow here.
            // Client ID looks like "9999999.apps.googleusercontent.com"
            static string clientId = "YOURCLIENTID";  
            static string clientSecret = "YOURSECRET";
    
            // Project ID is in the URL of your project on the APIs Console
            // Project ID looks like "999999";
            static string projectId = "YOURPROJECTID";
    
            // Query in SQL-like form
            static string query = "SELECT state, count(*) from [publicdata:samples.natality] GROUP BY state ORDER BY state ASC";
    
            public static void Main(string[] args)
            {
                // Register an authenticator.
                var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description);
    
                provider.ClientIdentifier = clientId;
                provider.ClientSecret = clientSecret;
    
                // Initiate an OAuth 2.0 flow to get an access token
                
                var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthorization);
    
                // Create the service.
                var service = new BigqueryService(auth);
                JobsResource j = service.Jobs;
                QueryRequest qr = new QueryRequest();
                qr.Query = query;
    
                QueryResponse response = j.Query(qr, projectId).Fetch();
                foreach (TableRow row in response.Rows)
                {
                    List<string> list = new List<string>();
                    foreach (TableRow.FData field in row.F)
                    {
                        list.Add(field.V);
                    }
                    Console.WriteLine(String.Join("\t", list));
                }
                Console.WriteLine("\nPress enter to exit");
                Console.ReadLine();
            }
    
            private static IAuthorizationState GetAuthorization(NativeApplicationClient arg)
            {
                // Get the auth URL:
                IAuthorizationState state = new AuthorizationState(new[] {  BigqueryService.Scopes.Bigquery.GetStringValue() });
                state.Callback = new Uri(NativeApplicationClient.OutOfBandCallbackUrl);
                Uri authUri = arg.RequestUserAuthorization(state);
    
                // Request authorization from the user (by opening a browser window):
                Process.Start(authUri.ToString());
                Console.Write("  Authorization Code: ");
                string authCode = Console.ReadLine();
                Console.WriteLine();
    
                // Retrieve the access token by using the authorization code:
                return arg.ProcessUserAuthorization(authCode, state);
            }
        }
    }
