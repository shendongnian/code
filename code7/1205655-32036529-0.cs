        static void GetCloudServiceDetails()
        {
            var subscriptionId = "<your azure subscription id>";
            var managementCertDataFromPublishSettingsFile = "<management cert data from a publish settings file>";
            var cert = new X509Certificate2(Convert.FromBase64String(managementCertDataFromPublishSettingsFile));
            var credentials = new CertificateCloudCredentials(subscriptionId, cert);
            var computeManagementClient = new ComputeManagementClient(credentials);
            var cloudServiceName = "<your cloud service name>";
            var cloudServiceDetails = computeManagementClient.HostedServices.GetDetailed(cloudServiceName);
            var deployments = cloudServiceDetails.Deployments;
            foreach (var deployment in deployments)
            {
                Console.WriteLine("Deployment Slot: " + deployment.DeploymentSlot);
                Console.WriteLine("-----------------------------------------------");
                foreach(var instance in deployment.RoleInstances)
                {
                    Console.WriteLine("Instance name: " + instance.InstanceName + "; IP Address: " + instance.IPAddress);
                }
            }
        }
