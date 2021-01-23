    public static class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            // register extension before use container!
            container.AddExtension(new DefaultRegistrationFallbackConfiguration());
            container.RegisterType(typeof(IFoo), typeof(FooDefault));
            container.RegisterType(typeof(IFoo), typeof(FooNamed), "named");
            container.Resolve<IFoo>()         .Bar(); // default one
            container.Resolve<IFoo>("named")  .Bar(); // named one
            container.Resolve<IFoo>("unknown").Bar(); // default one
        }
    }
