    public static class Interceptor
    {
        private static readonly ProxyGenerator generator = new ProxyGenerator();
        public static object CreateProxy(Type type, IInterceptor interceptor,
            object target)
        {
            return generator.CreateInterfaceProxyWithTarget(type, target, interceptor);
        }
    }
