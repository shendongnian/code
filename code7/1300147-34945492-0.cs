    public class AuthenticationService
    {
         private readonly ICrudFactory _factory;
         public AuthenticationService([Dependency("ZNodeData")] ICrudFactory factory)
         {
             _factory = factory;
         }
    }
