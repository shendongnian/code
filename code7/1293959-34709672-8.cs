    public static class MyContainerExtension 
    {
        public static void Configure<T>(this IMyContainer container, Action<T> config) where T : class, new()
        {
            var t = new T();
            config(t);
            container.AddSingelton<IConfiguration<T>>(t);
        }
    }
