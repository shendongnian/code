    public static void GetVirtualMachine(TokenCredentials credential, string groupName, string vmName, string subscriptionId)
    {
       Console.WriteLine("Getting information about the virtual machine...");
       var computeManagementClient = new ComputeManagementClient(credential);
       computeManagementClient.SubscriptionId = subscriptionId;
       var vmResult = computeManagementClient.VirtualMachines.Get(groupName, vmName, "instanceview");
       Console.WriteLine("hardwareProfile");
       Console.WriteLine("   vmSize: " + vmResult.HardwareProfile.VmSize);
       Console.WriteLine("\nstorageProfile");
       Console.WriteLine("   imageReference");
       Console.WriteLine("       publisher: " + vmResult.StorageProfile.ImageReference.Publisher);
       Console.WriteLine("       offer: " + vmResult.StorageProfile.ImageReference.Offer);
       Console.WriteLine("       sku: " + vmResult.StorageProfile.ImageReference.Sku);
       Console.WriteLine("       version: " + vmResult.StorageProfile.ImageReference.Version);
       Console.WriteLine("   osDisk");
       Console.WriteLine("       osType: " + vmResult.StorageProfile.OsDisk.OsType);
       Console.WriteLine("       name: " + vmResult.StorageProfile.OsDisk.Name);
       Console.WriteLine("       createOption: " + vmResult.StorageProfile.OsDisk.CreateOption);
       Console.WriteLine("       uri: " + vmResult.StorageProfile.OsDisk.Vhd.Uri);
       Console.WriteLine("       caching: " + vmResult.StorageProfile.OsDisk.Caching);
       Console.WriteLine("\nosProfile");
       Console.WriteLine("   computerName: " + vmResult.OsProfile.ComputerName);
       Console.WriteLine("   adminUsername: " + vmResult.OsProfile.AdminUsername);
       Console.WriteLine("   provisionVMAgent: " + vmResult.OsProfile.WindowsConfiguration.ProvisionVMAgent.Value);
       Console.WriteLine("   enableAutomaticUpdates: " + vmResult.OsProfile.WindowsConfiguration.EnableAutomaticUpdates.Value);
       Console.WriteLine("\nnetworkProfile");
       foreach (NetworkInterfaceReference nic in vmResult.NetworkProfile.NetworkInterfaces)
       {
          Console.WriteLine("    networkInterface id: " + nic.Id);
       }
       Console.WriteLine("\nvmAgent");
       Console.WriteLine("    vmAgentVersion" + vmResult.InstanceView.VmAgent.VmAgentVersion);
       Console.WriteLine("    statuses");
       foreach (InstanceViewStatus stat in vmResult.InstanceView.VmAgent.Statuses)
       {
          Console.WriteLine("        code: " + stat.Code);
          Console.WriteLine("        level: " + stat.Level);
          Console.WriteLine("        displayStatus: " + stat.DisplayStatus);
          Console.WriteLine("        message: " + stat.Message);
          Console.WriteLine("        time: " + stat.Time);
       }
       Console.WriteLine("\ndisks");
       foreach (DiskInstanceView idisk in vmResult.InstanceView.Disks)
       {
          Console.WriteLine("    name: " + idisk.Name);
          Console.WriteLine("    statuses");
          foreach (InstanceViewStatus istat in idisk.Statuses)
          {
             Console.WriteLine("        code: " + istat.Code);
             Console.WriteLine("        level: " + istat.Level);
             Console.WriteLine("        displayStatus: " + istat.DisplayStatus);
             Console.WriteLine("        time: " + istat.Time);
          }
       }
       Console.WriteLine("\nVM general status");
       Console.WriteLine("   provisioningStatus: " + vmResult.ProvisioningState);
       Console.WriteLine("   id: " + vmResult.Id);
       Console.WriteLine("   name: " + vmResult.Name);
       Console.WriteLine("   type: " + vmResult.Type);
       Console.WriteLine("   location: " + vmResult.Location);
       Console.WriteLine("\nVM instance status");
       foreach (InstanceViewStatus istat in vmResult.InstanceView.Statuses)
       {
          Console.WriteLine("\n   code: " + istat.Code);
          Console.WriteLine("   level: " + istat.Level);
          Console.WriteLine("   displayStatus: " + istat.DisplayStatus);
       }
    }
