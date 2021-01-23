    services.AddSingleton<IConnectionFactory>(new ConnectionFactory("ReadDB"));
    services.AddSingleton<IConnectionFactory>(new ConnectionFactory("WriteDB"));
    services.AddSingleton<IConnectionFactory>(new ConnectionFactory("TestDB"));
    services.AddSingleton<IConnectionFactory>(new ConnectionFactory("Analytics"));
    services.AddSingleton<IConnectionFactory>(new ConnectionFactory("LogDB"));
    // https://stackoverflow.com/questions/39174989/how-to-register-multiple-implementations-of-the-same-interface-in-asp-net-core
    services.AddTransient<Func<string, IConnectionFactory>>(
        delegate(IServiceProvider sp)
        {
            return
                delegate(string key)
                {
                    System.Collections.Generic.IEnumerable<IConnectionFactory> svs = 
                        sp.GetServices<IConnectionFactory>();
                    
                    foreach (IConnectionFactory thisService in svs)
                    {
                        if (key.Equals(thisService.Name, StringComparison.OrdinalIgnoreCase))
                            return thisService;
                    }
        
                    return null;
                };
        });
