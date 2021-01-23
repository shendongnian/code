        public enum ServiceType
        {
           SimpleService,
           .
           .
        }
    
        // For naming convention use CreateService
        IServiceBase service = ServiceFactory.GetService(ServiceType.SimpleService);
    
       
       public class ServiceFactory
       {
          public static T GetService(enum type)
          {
             // create you service here         
          }
       }
   
