    public static void RegisterTypes(IUnityContainer container)
        {
            // Some other types registration .
			
            container.RegisterType<StoreDetails>(
                //new PerResolveLifetimeManager(), 
                new InjectionFactory(c => {
                    int storeId;
                    if(int.TryParse(HttpContext.Current.Request.Headers["StoreId"], out storeId)) {
                        return new StoreDetails {StoreId = storeId};
                    }
                    return null;
                }));
        }
