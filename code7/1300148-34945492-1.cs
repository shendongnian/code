        public class AuthenticationService
        {
             private readonly IEnumerable<ICrudFactory> _factories;
             public AuthenticationService(ICrudFactory[] factories)
             {
                 // Now you got both...
                 _factories = factories;
                 var zNodeFactory = _factories.FirstOrDefault(x => x.Factory == ZNode);
             }
        }
    
    
        public interface ICrudFactory
        {
             ICrud Create();
             // Something to identify the type of data. Maybe an enum?
             FactoryType Factory {get;}
        }
    
    public ZNodeDataContextFactory : ICrudFactory
    {
         ICrud ICrudFactory.Create()
         {
               return ZNodeDataContext();
         }
    
         FactoryType ICrudFactory.Factory
         {
            {get {return FactoryType.ZNode;}
         }
    }
