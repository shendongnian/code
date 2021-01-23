    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions
                .Add(StaticResourceConventionBuilder.AddDirectory("/Scripts", GetType().Assembly, "MyAssembly.Scripts"));
        }
    }
