    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            // for views in referenced projects
            nancyConventions.ViewLocationConventions.Add(
                (viewName, model, context) => string.Concat("bin/views/", viewName));
            // for assets in referenced projects         
            nancyConventions.StaticContentsConventions.Add(
                Nancy.Conventions.StaticContentConventionBuilder.AddDirectory("assets", "bin/assets"));
        }
    }
