    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Core;
    using Microsoft.Extensions.DependencyInjection;
    public void ConfigureServices(IServiceCollection services)
    {        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddMvcCore();
    }
