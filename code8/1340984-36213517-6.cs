    [TestClass]
    public class UnitTest1
    {
        private IUnityContainer _container;
        [TestInitialize]
        public void InitializeTest()
        {
           _container = new UnityContainer();
           var configurer = new ContainerConfiguration();
           configurer.Configure(_container);
        }
        [TestCleanup]
        public void CleanupTest()
        {
            _container.Dispose();
        }
        [TestMethod]
        public void ThingINeedFactory_CreatesExpectedType()
        {
            var factory = _container.Resolve<IThingINeedFactory>();
            var needsThing = new NeedsThing(factory);
            var output = needsThing.PerformSomeFunction(ThingTypes.B);
            Assert.AreEqual(output, typeof(ThingB).Name);
        }
        [TestMethod]
        public void ThingINeedFactory_CreatesDefaultyTpe()
        {
            var factory = _container.Resolve<IThingINeedFactory>();
            var needsThing = new NeedsThing(factory);
            var output = needsThing.PerformSomeFunction(ThingTypes.D);
            Assert.AreEqual(output, typeof(ThingC).Name);
        }
    }
