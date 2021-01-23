    using System;
    using net.openstack.Core.Domain;
    using net.openstack.Providers.Rackspace;
    namespace CloudFileSubdirectories
    {
        public class Program
        {
            public static void Main()
            {
                // Authenticate
                const string region = "DFW";
                var user = new CloudIdentity
                {
                    Username = "username",
                    APIKey = "apikey"
                };
                var cloudfiles = new CloudFilesProvider(user);
                // Create a container
                cloudfiles.CreateContainer("images", region: region);
                // Make the container publically accessible
                long ttl = (long)TimeSpan.FromMinutes(15).TotalSeconds;
                cloudfiles.EnableCDNOnContainer("images", ttl, region);
                var cdnInfo = cloudfiles.GetContainerCDNHeader("images", region);
                string containerPrefix = cdnInfo.CDNUri;
                // Upload a file to a "subdirectory" in the container
                cloudfiles.CreateObjectFromFile("images", @"C:\tiny-logo.png", "thumbnails/logo.png", region: region);
                // Print out the URL of the file
                Console.WriteLine($"Uploaded to {containerPrefix}/thumbnails/logo.png");
                // Uploaded to http://abc123.r27.cf1.rackcdn.com/thumbnails/logo.png
            }
        }
    }
