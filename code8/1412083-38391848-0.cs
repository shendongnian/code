    using MvcSiteMapProvider;
    using MvcSiteMapProvider.Reflection;
    public class MyCompositeVisibilityProvider : CompositeSiteMapNodeVisibilityProvider
    {
        public MyCompositeVisibilityProvider()
            : base(
                this.GetType().ShortAssemblyQualifiedName(), 
                new ISiteMapNodeVisibilityProvider[] { 
                    // Note that the visibility providers are executed in
                    // the order specified here, but execution stops when
                    // the first visibility provider returns false.
                    new FilteredSiteMapNodeVisibilityProvider(), 
                    new CustomVisibilityProvider() 
                }
            )
        {}
    }
