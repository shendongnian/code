    public static class ResolverHelper {
        public static void OverrideDefaultResolver(this HttpConfiguration httpConfiguration) {
            var resolver = new MyCustomDependencyResolver();
            httpConfiguration.DependencyResolver = resolver;
        }
    }
