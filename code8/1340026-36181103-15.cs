    public static class ResolverHelper {
        public static void OverrideResolver(this HttpConfiguration httpConfiguration) {
            var innerResolver = httpConfiguration.DependencyResolver;
            var resolver = new MyDryIocDependencyResolver(innerResolver);
            httpConfiguration.DependencyResolver = resolver;
        }
    }
