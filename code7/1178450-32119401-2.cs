    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Auth.OAuth2.Flows;
    using Google.Apis.Auth.OAuth2.Requests;
    using Google.Apis.Util.Store;
    
    namespace OAuth2
    {    
        public class dsAuthorizationBroker : GoogleWebAuthorizationBroker
        {
            public static string RedirectUri;
    
            public new static async Task<UserCredential> AuthorizeAsync(
                ClientSecrets clientSecrets,
                IEnumerable<string> scopes,
                string user,
                CancellationToken taskCancellationToken,
                IDataStore dataStore = null)
            {
                var initializer = new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = clientSecrets,
                };
                return await AuthorizeAsyncCore(initializer, scopes, user,
                    taskCancellationToken, dataStore).ConfigureAwait(false);
            }
    
            private static async Task<UserCredential> AuthorizeAsyncCore(
                GoogleAuthorizationCodeFlow.Initializer initializer,
                IEnumerable<string> scopes,
                string user,
                CancellationToken taskCancellationToken,
                IDataStore dataStore)
            {
                initializer.Scopes = scopes;
                initializer.DataStore = dataStore ?? new FileDataStore(Folder);
                var flow = new dsAuthorizationCodeFlow(initializer);
                return await new AuthorizationCodeInstalledApp(flow, 
                    new LocalServerCodeReceiver())
                    .AuthorizeAsync(user, taskCancellationToken).ConfigureAwait(false);
            }
        }
    
    
        public class dsAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
        {
            public dsAuthorizationCodeFlow(Initializer initializer)
                : base(initializer) { }
    
            public override AuthorizationCodeRequestUrl
                           CreateAuthorizationCodeRequest(string redirectUri)
            {
                return base.CreateAuthorizationCodeRequest(dsAuthorizationBroker.RedirectUri);
            }
        }    
    }
