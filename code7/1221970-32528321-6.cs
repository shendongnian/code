    using System;
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace CreateNewAzureSQLServer
    {
        class Program
        {
            private static string
    
                domain = "MY_DOMAIN.onmicrosoft.com",
                resource = "https://management.azure.com/",
                subscriptionId = "xx-xx-xx-xx",
    
                clientId_web = "xx-xx-xx-xx",
                clientSecret_web = "xxxxx==",
    
                clientId_native = "xx-xx-xx-xx",
                clientUri_native = "http://MY_REDIRECT_URL",
    
                adminAccountName = "MY_ADMIN_ACCOUNT_NAME",
                adminAccountPwd = "MY_ACCOUNT_ADMIN_PWD",
                resourceGroupName = "MY_RESOURCE_GROUP_NAME",
                serverName = "MY_SERVER_NAME",
                location = "West US";
    
            // this is what works with a Web Application to authenticate
            private static AuthenticationResult GetAccessTokenWithClientSecret()
            {
                var authority = "https://login.windows.net/" + domain;
                var authContext = new AuthenticationContext(authority);
                var token = authContext.AcquireToken(
                    resource,
                    new ClientCredential(clientId_web, clientSecret_web));
                return token;
            }
    
            // This is what works with a native application to authenticate
            private static AuthenticationResult GetAccessTokenWithUserName()
            {
                var authority = "https://login.windows.net/" + domain;
                var authContext = new AuthenticationContext(authority);
                AuthenticationResult token = authContext.AcquireToken(
                    resource,
                    clientId_native,
                    new Uri(clientUri_native),
                    PromptBehavior.Auto);
    
                return token;
            }
    
            // This works with a native application not with a web application
            // Perhaps using a native app is required for now
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
                ServerGetResponse aCreateResponse
                    = client.Servers.CreateOrUpdate(resourceGroupName, serverName, parameters);
            }
    
            // This also works only with a native application
            static void CreateResourceGroup(TokenCloudCredentials creds)
            {
                var resourceClient = new ResourceManagementClient(creds);
                var resourceGroupParameters = new ResourceGroup()
                {
                    Location = location
                };
                var resourceGroupResult = resourceClient.ResourceGroups.CreateOrUpdate(resourceGroupName, resourceGroupParameters);
            }
    
            // This only works when using a Native App
            // Using a web app leads to the same error that you received.
            static void Main(string[] args)
            {
                var token = GetAccessTokenWithUserName();
                var creds = new TokenCloudCredentials(subscriptionId, token.AccessToken);
                CreateResourceGroup(creds);
                CreateSqlServer(creds);
            }
        }
    }
