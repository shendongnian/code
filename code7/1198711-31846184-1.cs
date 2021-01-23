    var providers = GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();
    GlobalConfiguration.Configuration.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider),
                                                    new UnityFilterProvider(container));
    var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
    GlobalConfiguration.Configuration.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
