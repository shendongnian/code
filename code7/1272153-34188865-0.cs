    using System;
    using System.Collections.Generic;
    using net.openstack.Core.Domain;
    using net.openstack.Core.Providers;
    using net.openstack.Providers.Rackspace;
    namespace CloudFilesVersioning
    {
        class Program
        {
            static void Main(string[] args)
            {
                var identityUrl = new Uri("{identity-url}");
                var identity = new CloudIdentityWithProject
                {
                    Username = "{user}",
                    ProjectName = "{project-name}",
                    Password = "{password}"
                };
                const string region = "RegionOne";
                var identityProvider = new OpenStackIdentityProvider(identityUrl, identity);
                var filesProvider = new CloudFilesProvider(null, identityProvider);
                // Create versions container
                const string versionContainerName = "mycontainer-versions";
                filesProvider.CreateContainer(versionContainerName, region: region);
                // Create main container
                const string containerName = "mycontainer";
                var headers = new Dictionary<string, string>
                {
                    {"X-Versions-Location", versionContainerName}
                };
                filesProvider.CreateContainer(containerName, headers, region);
                // Upload the initial file
                filesProvider.CreateObjectFromFile(containerName, @"C:\thing-v1.txt", "thing.txt", region: region);
                // Upload the same file again, this should not create a new version
                filesProvider.CreateObjectFromFile(containerName, @"C:\thing-v1.txt", "thing.txt", region: region);
                // Upload a new version of the file
                filesProvider.CreateObjectFromFile(containerName, @"C:\thing-v2.txt", "thing.txt", region: region);
            }
        }
    }
