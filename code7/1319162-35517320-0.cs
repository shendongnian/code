        public class SingletonConvention<TPluginFamily> : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete() || !type.CanBeCreated() || !type.AllInterfaces().Contains(typeof(TPluginFamily)))
                return;
            registry.For(typeof(TPluginFamily)).Singleton().Use(type).Named(type.Name);
        }
    }
