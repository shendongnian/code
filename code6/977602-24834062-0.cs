    var services = GetServices();
    var providers = GetProviders();
    var combined = providers.Select(x =>
    new{
            EId,
            Firstname,
            Lastname,
            EmailAddress,
            Services = services.Where(
                       y=> y.ResourceId == x.ResourceId
            ).ToList()
    });
