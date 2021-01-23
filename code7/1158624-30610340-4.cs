    public static void RegisterTypes(IUnityContainer container)
    
                {
                    
                    container.RegisterType<IProductosService, ProductosService>(new PerRequestLifetimeManager());
                    Synergy5.ComponentConfigure.UnityConfigure.RegisterTypes(container, ()
        => new PerRequestLifetimeManager());
        
                }
