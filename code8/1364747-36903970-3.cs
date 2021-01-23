    [Test]
    public void Controller_with_property_injection()
    {
        var config = new HttpConfiguration();
        var c = new Container()
            .With(rules => rules.With(propertiesAndFields: PropertiesAndFields.Auto))
            .WithWebApi(config, throwIfUnresolved: type => type.IsController());
        c.Register<A>(Reuse.Singleton);
        using (var scope = config.DependencyResolver.BeginScope())
        {
            var propController = (PropController)scope.GetService(typeof(PropController));
            Assert.IsNotNull(propController.A);
        }
    }
    public class PropController : ApiController
    {
        public A A { get; set; }
    }
    public class A {}
