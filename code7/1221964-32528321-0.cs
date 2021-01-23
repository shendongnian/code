    using Microsoft.Azure;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace CreateNewAzureSQLServer
    {
        class Program
        {
            private static string
    
                domain = "YOU.onmicrosoft.com",
                resource = "https://management.azure.com/",
                subscriptionId = "",
                
                clientId = "",
                clientSecret = "",
                
                adminAccountName = "arbitrary_string",
                adminAccountPwd = "arbitrary_string",
                resourceGroupName = "arbitrary_string",
                serverName = "arbitrary_string",
                location = "West US";
    
            private static AuthenticationResult GetAccessTokenWithClientSecret()
            {
                var authority = "https://login.windows.net/" + domain;
                var authContext = new AuthenticationContext(authority);
                var token = authContext.AcquireToken(
                    resource,
                    new ClientCredential(clientId, clientSecret));
                return token;
            }
    
            static void CreateSqlServer(TokenCloudCredentials creds)
            {
                var client = new SqlManagementClient(creds);
    
                var someProperties = new ServerCreateOrUpdateProperties
                {
                    AdministratorLogin = adminAccountName,
                    AdministratorLoginPassword = adminAccountPwd,
                    Version = "12"
                };
    
                var parameters = new ServerCreateOrUpdateParameters(someProperties, location);
    
                // {"AuthorizationFailed: 
                // The client 'xxxxx-xxxxx-xxxxx-xxxxx' with object id 'xxxxx-xxxxx-xxxxx-xxxxx' 
                // does not have authorization to perform action 'Microsoft.Sql/servers/write' over scope 
                // '/subscriptions/xxxxx-xxxxx-xxxxx-xxxxx/resourceGroups/xxxxxxx/providers/Microsoft.Sql/servers/xxxxxxx'."}
                ServerGetResponse aCreateResponse
                    = client.Servers.CreateOrUpdate(resourceGroupName, serverName, parameters);
            }
    
            static void Main(string[] args)
            {
                var token = GetAccessTokenWithClientSecret();
                var creds = new TokenCloudCredentials(subscriptionId, token.AccessToken);
    
                CreateSqlServer(creds);
            }
        }
    }
