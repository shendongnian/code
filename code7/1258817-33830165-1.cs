    public Task Run<T>(Action<T> action)
    {
        Task.Factory.StartNew(() =>
        {
            using (var lifetimeScope = _container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag))
            {
                var service = lifetimeScope.Resolve<T>();
                action(service);
            }
        });
        return Task.FromResult(0);
    }
