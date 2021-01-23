    public static class IocContainer
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            
            // Do your registrations.
            container.RegisterType<IService, EstattoriService>(RegisteredServices.Estrattori.ToString());
            container.RegisterType<IService, StandardService>(RegisteredServices.Anagrafica.ToString());
            container.RegisterType<IService, PrivacyService>(RegisteredServices.Privacy.ToString()); 
            container.RegisterType<IService, ListAnagService>(RegisteredServices.ListaAnagrafica.ToString()); 
    
            return container;
        });
    
        public static IUnityContainer Instance
        {
            get { return Container.Value; }
        }
    }
