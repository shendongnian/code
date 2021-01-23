    public static class WarmupServiceProviderExtensions
    {
        public static void WarmUp(this IServiceProvider app)
        {
            // Just call it to resolve, no need to safe a reference
            app.RequestService<ISomeRepository>();
        }
    }
