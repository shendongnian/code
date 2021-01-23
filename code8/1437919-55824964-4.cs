    services.AddTransient<Func<string, IConnectionFactory>>(
        delegate (IServiceProvider sp)
        {
            return
                delegate (string key)
                {
                    System.Collections.Generic.Dictionary<string, IConnectionFactory> dbs = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService
     <System.Collections.Generic.Dictionary<string, IConnectionFactory>>(sp);
                    if (dbs.ContainsKey(key))
                        return dbs[key];
                    throw new System.Collections.Generic.KeyNotFoundException(key); // or maybe return null, up to you
                };
        });
