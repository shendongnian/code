    using System;
    using net.openstack.Core.Domain;
    using net.openstack.Providers.Rackspace;
    namespace CloudFilesDateModified
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string region = "DFW";
                var identity = new CloudIdentity { Username = "username", APIKey = "apikey" };
                var cloudfiles = new CloudFilesProvider(identity);
                foreach (Container container in cloudfiles.ListContainers(region:region))
                {
                    Console.WriteLine($"Container: {container.Name}");
                    foreach (ContainerObject file in cloudfiles.ListObjects(container.Name, region: region))
                    {
                        Console.WriteLine($"\t{file.Name} - {file.LastModified}");
                    }
                }
                Console.ReadLine();
            }
        }
    }
