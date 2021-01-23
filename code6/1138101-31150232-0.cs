    // Create Web Hosting Plan
    var hostingPlanParams = new WebHostingPlanCreateOrUpdateParameters
    {
        WebHostingPlan = new WebHostingPlan()
        {
            Name = "WebHostingPlanName",
            Location = "Australia Southeast",
            Properties = new WebHostingPlanProperties
            {
                NumberOfWorkers = 1,
                Sku = SkuOptions.Standard,
                WorkerSize = WorkerSizeOptions.Small
            }
        },
    };
    var result = this.ManagementContext.WebSiteManagementClient.WebHostingPlans.CreateOrUpdateAsync(
            "ResourceGroupName",
            "WebHostingPlanName",
            CancellationToken.None).Result;
    // Create Website
    var websiteParams = new WebSiteCreateOrUpdateParameters
    {
        WebSite = new WebSiteBase
        {
            Location = "Australia Southeast",
            Name = "WebSiteName",
            Properties = new WebSiteBaseProperties
            {
                ServerFarm = "WebHostingPlanName"
            }
        }
    };
    var siteResult = this.ManagementContext.WebSiteManagementClient.WebSites.CreateOrUpdateAsync(
            "ResourceGroupName",
            "WebSiteName",
            null,
            websiteParams,
            CancellationToken.None).Result;
