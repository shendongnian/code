    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    namespace BearerTokenFromAzureAD
    {
        class Program
        {
            /// <summary>
            /// 
            /// </summary>
            const string AUTHORITY = 
                "https://login.microsoftonline.com/bigfontoutlook.onmicrosoft.com/";
            /// <summary>
            /// 
            /// </summary>
            const string GATEWAY_URL = 
                "https://mvp201514929cfc350148cfa5c9b24a7daaf694.azurewebsites.net/";
            /// <summary>
            /// 
            /// </summary>
            const string API_ID_URL = 
                GATEWAY_URL + "login/aad";
            /// <summary>
            /// 
            /// </summary>
            const string API_REPLY_URL = 
                GATEWAY_URL + "signin-aad";
            /// <summary>
            /// 
            /// </summary>
            const string CLIENT_ID = 
                "0d7dce06-c3e3-441f-89a7-f828e210ff6d";
            /// <summary>
            /// 
            /// </summary>
            const string CLIENT_SECRET = 
                "AtRMr+Rijrgod4b9Q34i/UILldyJ2VO6n2jswkcVNDs=";
            /// <summary>
            /// 
            /// </summary>
            const string WEB_API_GET_URL = "https://microsoft-apiappf47e0f10a7814ffcb9b51cc8b2e77f52.azurewebsites.net/api/contacts/get";
            static void Main(string[] args)
            {
                var authContext = new AuthenticationContext(AUTHORITY);
                var credential = new ClientCredential(CLIENT_ID, CLIENT_SECRET);
                var result = (AuthenticationResult)authContext
                    .AcquireTokenAsync(API_ID_URL, credential)
                    .Result;
                var token = result.AccessToken;
                Console.WriteLine(token.ToString());
                Console.ReadLine();
            }
        }
    }
