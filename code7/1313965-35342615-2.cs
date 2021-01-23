    using Microsoft.Extensions.DependencyInjection;
    public static IServiceCollection AddMyFoo(this IServiceCollection services)
    {
            services.AddTransient<DAL.IRepository<Models.Order>, DAL.Repository<Models.Order>>();
			//....
            
            return services;
    }
