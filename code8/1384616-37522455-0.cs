    using System;
    using Microsoft.WindowsAzure.Management.WebSites;
    using Microsoft.WindowsAzure.Management.WebSites.Models;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure;
    namespace updateWebApp
    {
        class Program
        {
            private static WebSiteManagementClient _WebSiteClient;
            private static String SubscriptionId = "<your subscription id>";
            private static X509Certificate2 cert = new X509Certificate2("E:/path/azure.cer");
            private static String webspace = "<your webspace name>";
            private static String websitename = "<your web site name>";
            static void Main(string[] args)
            {
                var credential = new CertificateCloudCredentials(SubscriptionId, cert);
                _WebSiteClient = new WebSiteManagementClient(credential);
                var web = _WebSiteClient.WebSites.Get(webspace, websitename, null).WebSite;
                web.HostNames.Add("www.example.com");
                var updates = new WebSiteUpdateParameters{
                    HostNames = web.HostNames,
                    ServerFarm = web.ServerFarm,
                    State = web.State
                };
                _WebSiteClient.WebSites.Update(webspaces, websitename, updates);
                System.Console.WriteLine("Press ENTER to continue");
                System.Console.ReadLine();
            }
        }
    }
