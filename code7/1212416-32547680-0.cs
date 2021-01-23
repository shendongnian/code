    public class Bootstrapper : DefaultNancyAspNetBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var assemblyClasses = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsClass);
            foreach (var assemblyClass in assemblyClasses)
            {
                var interfaces = assemblyClass.GetInterfaces();
                if (interfaces.Count() == 1)
                {
                    container.Register(interfaces[0], assemblyClass).AsPerRequestSingleton();
                }
            }
        }
