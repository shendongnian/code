        public static class QueryHandlerRegistration
    {
        public static IServiceCollection RegisterQueryHandler<TQueryHandler, TQuery, TResult>(
            this IServiceCollection services) 
            where TQuery : IQuery<TResult>
            where TQueryHandler : class, IQueryHandler<TQuery, TResult>
        {
            
            services.AddTransient<TQueryHandler>();
            services.AddTransient<IQueryHandler<TQuery, TResult>>(x =>
                new LoggingDecorator<TQuery, TResult>(x.GetService<ILogger<TQuery>>(), x.GetService<TQueryHandler>()));
            return services;
        }
    }
