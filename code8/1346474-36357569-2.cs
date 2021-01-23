    var svc = new Service
    {
        Name = "Service1",
        Granularity = "FREQ=MINUTELY;INTERVAL=15",
        ResourceSpecId = new EntityReference(ResourceSpec.EntityLogicalName, resSpecId),
        InitialStatusCode = new OptionSetValue(0),
        Duration = 15
    };
    OrganizationService.Create(svc);
