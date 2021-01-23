    For<ISerializer>().Singleton().Use<JilSerializer>();
    For<IRedisCachingConfiguration>().Singleton()
        .Use("null config", () => (IRedisCachingConfiguration)null);
    For<ICacheClient>().Singleton()
        .Use<StackExchangeRedisCacheClient>()
        .SelectConstructor(() => new StackExchangeRedisCacheClient(
            (ISerializer)null,
            (IRedisCachingConfiguration)null));
