    internal class IoC{
      private static IUnityContainer container = new UnityContainer();
      private static bool isInitialized = false;
      private static readonly object padlock = new object(); // lock object.
    
    public static IUnityContainer Container
    {
        get
        {
            if (!isInitialized)
            {
                lock (padlock) // Lock on padlock instead.
                {
                    if (!isInitialized)
    
    
                        container.RegisterType<IService, EstattoriService>(RegisteredServices.Estrattori.ToString());
                        container.RegisterType<IService, StandardService>(RegisteredServices.Anagrafica.ToString());
                        container.RegisterType<IService, PrivacyService>(RegisteredServices.Privacy.ToString()); 
                        container.RegisterType<IService, ListAnagService>(RegisteredServices.ListaAnagrafica.ToString()); 
                                    isInitialized = true;
    
                    }
                }
            }
            return container;
        }
    }
