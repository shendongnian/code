    using (var AwsManagement = new Microsoft.WindowsAzure.Management.WebSites.WebSiteManagementClient(azureCredentials))
    {
        WebSiteCreateParameters parameters = new WebSiteCreateParameters()
        {
                Name = "myAws",
                // this Service Plan must be created before
                ServerFarm = "myServiceplan",
         };
          await AwsManagement.WebSites.CreateAsync("myWebSpace", parameters, CancellationToken.None);
    }
