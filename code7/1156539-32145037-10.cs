        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            //This is the important part:
            var container = UnityConfig.GetConfiguredContainer(); //This is a static class in the InversionOfControl project.
            //This is generic:
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
