    var providers = new List<Providers>()
    {
        new Providers() { ClientGuid = Guid.NewGuid(), UserName = "A", Password = "B" },
        new Providers() { ClientGuid = Guid.NewGuid(), UserName = "B", Password = "C" },
    };
    
    var parameters = new List<Parameters>()
    {
        new Parameters() { ClientGuid = providers.First().ClientGuid, StartDate = "C" },
        new Parameters() { ClientGuid = providers.First().ClientGuid, StartDate = "B" },
        new Parameters() { ClientGuid = providers.Take(2).Last().ClientGuid, StartDate = "Tomorrow!" },
        new Parameters() { ClientGuid = Guid.NewGuid(), StartDate = "Last year" },
    };
    
    var result = parameters
        .GroupBy(a => a.ClientGuid, a => a)
        .Join(
            providers,
            parameterGroup => parameterGroup.Key,
            provider => provider.ClientGuid,
            (parameterGroup, provider) => new { provider.ClientGuid, provider.UserName, MinStartDate = parameterGroup.Min(groupMember => groupMember.StartDate) });
