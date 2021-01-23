    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            // Insert our value provider factories at the beginning of the list 
            // so they override the default QueryStringValueProviderFactory
            ValueProviderFactories.Factories.Insert(
                0, new SingularOrPluralQueryStringValueProviderFactory("attribute", "attributes"));
            ValueProviderFactories.Factories.Insert(
                1, new SingularOrPluralQueryStringValueProviderFactory("attributeDelimiter", "attributesDelimiter"));
        }
    }
