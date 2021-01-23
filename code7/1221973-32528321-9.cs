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
                subscriptionId = "xxxxx-xxxxx-xxxxx-xxxxx",
    
                // web
                clientId_web = "xxxxx-xxxxx-xxxxx-xxxxx",
                clientSecret_web = "xxxxx=",
                redirectUri_web = "http://myWebApp",
    
                // native
                clientId_native = "xxxxx-xxxxx-xxxxx-xxxxx",
                clientSecret_native = string.Empty,
                redirectUri_native = "http://myNativeClientApp",
    
                // adminstrator
                userName = "MY_USERNAME",
                userPassword = "MY_PASSWORD",
    
                // create
                adminAccountName = "MY_ADMIN_ACCOUNT_NAME",
                adminAccountPwd = "MY_ACCOUNT_ADMIN_PWD",
                resourceGroupName = "MY_RESOURCE_GROUP_NAME",
                serverName = "MY_SERVER_NAME",
                location = "West US";
    
            private static AuthenticationResult GetAccessToken(
                string clientId, string redirectUri, string clientSecret, AuthType type)
            {
                var authority = "https://login.windows.net/" + domain;
                var authContext = new AuthenticationContext(authority);
                authContext.TokenCache.Clear();
                AuthenticationResult token = null;
    
                switch (type)
                {
                    case AuthType.ClientCertificate:
                        throw new NotImplementedException();
                        break;
    
                    case AuthType.ClientAssertion:
                        throw new NotImplementedException();
                        break;
    
                    case AuthType.ClientCredential:                       
                        token = authContext.AcquireToken(resource,
                            new ClientCredential(clientId, clientSecret));
                        break;
    
                    case AuthType.ClientId_UserAssertion:
                        throw new NotImplementedException();
                        break;
    
                    case AuthType.ClientCredential_UserAssertion:
                        token = authContext.AcquireToken(resource,
                            new ClientCredential(clientId, clientSecret),
                            new UserAssertion(userPassword, "username", userName));
                        break;
    
                    case AuthType.ClientAssertion_UserAssertion:
                        throw new NotImplementedException();
                        break;
    
                    case AuthType.ClientCertificate_UserAssertion:
                        throw new NotImplementedException();
                        break;
    
                    case AuthType.ClientId_RedirectUri:
                        throw new NotImplementedException();
                        break;
    
                    case AuthType.ClientId_UserCredential:
                        token = authContext.AcquireToken(resource,
                            clientId,
                            new UserCredential(userName, userPassword));
                        break;
    
                    case AuthType.ClientId_RedirectUri_PromptBehavior:
                        token = authContext.AcquireToken(resource,
                            clientId,
                            new Uri(redirectUri),
                            PromptBehavior.Auto);
                        break;
    
                    case AuthType.ClientId_RedirectUri_PromptBehavior_UserIdentifier:                        
                        var cred = new UserCredential(userName);
                        token = authContext.AcquireToken(resource,
                            clientId,
                            new Uri(redirectUri),
                            PromptBehavior.Auto,
                            new UserIdentifier(cred.UserName, UserIdentifierType.RequiredDisplayableId));
                        break;
    
                    case AuthType.ClientId_RedirectUri_PromptBehavior_UserIdentifier_ExtraQueryParams:
                        throw new NotImplementedException();
                        break;
    
                    default:
                        break;
                };
    
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
                ServerGetResponse aCreateResponse
                    = client.Servers.CreateOrUpdate(resourceGroupName, serverName, parameters);
            }
    
            static string CreateResourceGroup(TokenCloudCredentials creds)
            {
                var uniqueResourceGroupName = resourceGroupName + DateTime.Now.Ticks.ToString();
                var resourceClient = new ResourceManagementClient(creds);
                var resourceGroupParameters = new ResourceGroup()
                {
                    Location = location
                };
                var resourceGroupResult = resourceClient
                    .ResourceGroups
                    .CreateOrUpdate(uniqueResourceGroupName, resourceGroupParameters);
    
                return uniqueResourceGroupName;
            }
    
            static void Main(string[] args)
            {
                foreach (AppType appType in Enum.GetValues(typeof(AppType)))
                {
                    var clientId = appType == AppType.WebApp ? clientId_web : clientId_native;
                    var clientSecret = appType == AppType.WebApp ? clientSecret_web : clientSecret_native;
                    var redirectUri = appType == AppType.WebApp ? redirectUri_web : redirectUri_native;
    
                    foreach (AuthType authType in Enum.GetValues(typeof(AuthType)))
                    {
                        try
                        {
                            Console.WriteLine(appType.ToString() + " with " + authType.ToString());
                            var token = GetAccessToken(clientId, redirectUri, clientSecret, authType);
                            var creds = new TokenCloudCredentials(subscriptionId, token.AccessToken);
                            var resourceGroupName = CreateResourceGroup(creds);
                            Console.WriteLine("Success! Created " + resourceGroupName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
    
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                }
    
                Console.WriteLine("Testing complete.:)");
                Console.ReadLine();
    
                //CreateSqlServer(creds);
            }
    
            enum AppType
            {
                WebApp,
                NativeClientApp
            }
    
            enum AuthType
            {
                ClientCertificate,
                ClientAssertion,
                ClientCredential,
                ClientId_UserAssertion,
                ClientCredential_UserAssertion,
                ClientAssertion_UserAssertion,
                ClientCertificate_UserAssertion,
                ClientId_RedirectUri,
                ClientId_UserCredential,
                ClientId_RedirectUri_PromptBehavior,
                ClientId_RedirectUri_PromptBehavior_UserIdentifier,
                ClientId_RedirectUri_PromptBehavior_UserIdentifier_ExtraQueryParams
            }
        }
    }
