    public static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            // register extension before use container!
            container.AddExtension(new DefaultRegistrationFallbackConfiguration());
            container.RegisterType(typeof(IFoo), typeof(FooDefault));
            container.RegisterType(typeof(IFoo), typeof(FooNamed), "named");
            var fooDefault = container.Resolve<IFoo>();
            fooDefault.Bar(); // default one
            var fooNamed = container.Resolve<IFoo>("named");
            fooNamed.Bar(); // named one
            var fooUnregisted = container.Resolve<IFoo>("unknown");
            fooUnregisted.Bar(); // default one
        }
    }
