            var allRepositories = GetType().GetTypeInfo()
            .Assembly.GetTypes().Where(p =>
                p.GetTypeInfo().IsClass &&
                !p.GetTypeInfo().IsAbstract &&
                typeof(IRepository).IsAssignableFrom(p));
            foreach (var repo in allRepositories)
            {
                var allInterfaces = repo .GetInterfaces();
                var mainInterfaces = allInterfaces.Except
                        (allInterfaces.SelectMany(t => t.GetInterfaces()));
                foreach (var itype in mainInterfaces)
                {
                    services.AddScoped(itype, repo);
                }
            }
