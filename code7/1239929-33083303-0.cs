    using System;
    using net.openstack.Core.Domain;
    using net.openstack.Providers.Rackspace;
    namespace ListCloudFiles
    {
        class Program
        {
            static void Main()
            {
                var region = "DFW";
                var identity = new CloudIdentity
                {
                    Username = "username",
                    APIKey = "apikey"
                };
                var cloudFilesProvider = new CloudFilesProvider(identity);
                foreach (Container container in cloudFilesProvider.ListContainers(region: region))
                {
                    Console.WriteLine(container.Name);
                
                    foreach (ContainerObject obj in cloudFilesProvider.ListObjects(container.Name, region: region))
                    {
                        Console.WriteLine(" * " + obj.Name);
                    }
                }
                Console.ReadLine();
            }
        }
    }
