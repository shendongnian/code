    using System;
    using System.Security;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Microsoft.Rest;
    namespace GetVmARM
    {
        class Program
        {
            private static String tenantID = "<your tenant id>";
            private static String loginEndpoint = "https://login.windows.net/";
            private static Uri redirectURI = new Uri("urn:ietf:wg:oauth:2.0:oob");
            private static String clientID = "1950a258-227b-4e31-a9cf-717495945fc2";
            private static String subscriptionID = "<your subscription id>";
            private static String resource = "https://management.core.windows.net/";
            static void Main(string[] args)
            {
                var token = GetTokenCloudCredentials();
                var credential = new TokenCredentials(token);
                var computeManagementClient = new ComputeManagementClient(credential);
                computeManagementClient.SubscriptionId = subscriptionID;
                InstanceViewTypes expand = new InstanceViewTypes();
                var vm = computeManagementClient.VirtualMachines.Get("<the resource group name>", "<the VM>", expand);
                System.Console.WriteLine(vm.InstanceView.Statuses[1].Code);
                System.Console.WriteLine("Press ENTER to continue");
                System.Console.ReadLine();
            }
            public static String GetTokenCloudCredentials(string username = null, SecureString password = null)
            {
                String authString = loginEndpoint + tenantID;
                AuthenticationContext authenticationContext = new AuthenticationContext(authString, false);
                var promptBehaviour = PromptBehavior.Auto;
                var userIdentifierType = UserIdentifierType.RequiredDisplayableId;
                var userIdentifier = new UserIdentifier("<your azure account>", userIdentifierType);
                var authenticationResult = authenticationContext.AcquireToken(resource, clientID, redirectURI, promptBehaviour, userIdentifier);
                return authenticationResult.AccessToken;
            }
        }
    }
