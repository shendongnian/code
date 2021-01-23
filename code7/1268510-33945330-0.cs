        interface IBetterServiceProvider : System.IServiceProvider
           {
               IList<object> GetAllServices();
               IList<Type> GetAllServicedTypes();
           }
    and make your services implement it.
