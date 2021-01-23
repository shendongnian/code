    using System;
    using System.Security;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Azure;
    namespace GetSqlARM
    {
        class Program
        {
            static void Main(string[] args)
            {
                var token = GetTokenCloudCredentials();
                SqlManagementClient client = new SqlManagementClient(token);
                var server = client.Servers.Get("<Your Resource Group>", "<Your Sql Server>");
                System.Console.WriteLine(server.ToString());
                System.Console.WriteLine("Press ENTER to continue");
                System.Console.ReadLine();
            }
            public static TokenCloudCredentials GetTokenCloudCredentials()
            {
                String tenantID = "<Your Tenant ID>";
                String loginEndpoint = "https://login.windows.net/";
                Uri redirectURI = new Uri("urn:ietf:wg:oauth:2.0:oob");
                String clientID = "1950a258-227b-4e31-a9cf-717495945fc2";
                String subscriptionID = "<Your Subscription ID>";
                String resource = "https://management.core.windows.net/";
                String authString = loginEndpoint + tenantID;
                AuthenticationContext authenticationContext = new AuthenticationContext(authString, false);
                var promptBehaviour = PromptBehavior.Auto;
                var userIdentifierType = UserIdentifierType.RequiredDisplayableId;
                var userIdentifier = new UserIdentifier("<Your Azure Account>", userIdentifierType);
                var authenticationResult = authenticationContext.AcquireToken(resource, clientID, redirectURI, promptBehaviour, userIdentifier);
                return new TokenCloudCredentials(subscriptionID, authenticationResult.AccessToken);
            }
        }
    }
