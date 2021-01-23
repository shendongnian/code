    public interface IThingINeed
    {}
    public class ThingA : IThingINeed { }
    public class ThingB : IThingINeed { }
    public class ThingC : IThingINeed { }
    public interface IThingINeedFactory
    {
        IThingINeed Create(ThingTypes thingType);
        void Release(IThingINeed created);
    }
    public class ThingINeedFactory : IThingINeedFactory
    {
        private readonly IUnityContainer _container;
        public ThingINeedFactory(IUnityContainer container)
        {
            _container = container;
        }
        public IThingINeed Create(ThingTypes thingType)
        {
            string dependencyName = "Thing" + thingType;
            if(_container.IsRegistered<IThingINeed>(dependencyName))
            {
                return _container.Resolve<IThingINeed>(dependencyName);
            }
            return _container.Resolve<IThingINeed>();
        }
        public void Release(IThingINeed created)
        {
            _container.Teardown(created);
        }
    }
    public class NeedsThing
    {
        private readonly IThingINeedFactory _factory;
        public NeedsThing(IThingINeedFactory factory)
        {
            _factory = factory;
        }
        public string PerformSomeFunction(ThingTypes valueThatDeterminesTypeOfThing)
        {
            var thingINeed = _factory.Create(valueThatDeterminesTypeOfThing);
            try
            {
                return thingINeed.GetType().Name;
            }
            finally
            {
                _factory.Release(thingINeed);
            }
        }
    }
    public enum ThingTypes
    {
        A, B, C, D
    }
    public class ContainerConfiguration
    {
        public void Configure(IUnityContainer container)
        {
            container.RegisterType<IThingINeedFactory,ThingINeedFactory>(new InjectionConstructor(container));
            container.RegisterType<IThingINeed, ThingA>("ThingA");
            container.RegisterType<IThingINeed, ThingB>("ThingB");
            container.RegisterType<IThingINeed, ThingC>("ThingC");
            container.RegisterType<IThingINeed, ThingC>();
        }
    }
