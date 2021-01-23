    //Register the filter injector
    var providers = config.Services.GetFilterProviders().ToList();
    var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
    config.Services.Remove(typeof(IFilterProvider), defaultprovider);
    config.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(UnityConfig.Container));
