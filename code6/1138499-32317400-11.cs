    using Microsoft.Extensions.DependencyInjection;
    ...
    public IServiceProvider Provider { get; set; }
    public ISomeService InjectedService { get; set; }
    public HomeController(IServiceProvider provider, ISomeService injectedService)
    {
        Provider = provider;
        InjectedService = Provider.GetService<ISomeService>();
    }
