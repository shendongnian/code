    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.Net;
    
    namespace AAD_SharePointOnlineApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var authContext =
                    new AuthenticationContext(Constants.AUTHORITY);
    
                var userCredential = 
                    new UserCredential(Constants.USER_NAME, Constants.USER_PASSWORD);
    
                var result = authContext
                    .AcquireTokenAsync(Constants.RESOURCE, Constants.CLIENT_ID_NATIVE, userCredential)
                    .Result;
    
                var token = result.AccessToken;
    
                var url = "https://mvp0.sharepoint.com/_api/search/query?querytext=%27timesheets%27";
                var request = WebRequest.Create(url);
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                var response = request.GetResponse() as HttpWebResponse;
            }
        }
    
        class Constants
        {
            public const string AUTHORITY =
                "https://login.microsoftonline.com/mvp0.onmicrosoft.com/";
        
            public const string RESOURCE =
                "https://mvp0.sharepoint.com";
    
            public const string CLIENT_ID_NATIVE = 
                "xxxxx-xxxx-xxxxx-xxxx-xxxxx-xxxx";
    
            public const string USER_NAME = 
                "MY_USER@mvp0.onmicrosoft.com";
    
            public const string USER_PASSWORD = 
                "MY_PASSWORD";
        }
    }
