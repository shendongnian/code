	// initialize resource management client
    var resourceManagement = new ResourceManagementClient(this.Credentials);
    resourceManagement.Providers.RegisterAsync("microsoft.insights").Result;
    // create identity & parameters for create call
	var resourceIdentity = new ResourceIdentity(
		"SomeResourceName", // ResourceName
		"microsoft.insights/components", // ResourceType
		"2014-04-01" // Api Version
	);
	var parameters = new GenericResource {
		Location = 'centralus'
	};
	// send call off and hope for the best
	var result = this.ManagementContext.ResourceManagement.Resources.CreateOrUpdateAsync(
	    "SomeResourceGroupName",
	    resourceIdentity,
	    parameters,
	    CancellationToken.None).Result;
