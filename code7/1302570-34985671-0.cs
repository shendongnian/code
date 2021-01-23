    public class MyApiController : ApiController
    {
        public MyApiController(IService service)
        { 
            //clearly MyApiController depends on IService
        }
    }
    public class MyService : IService
    {
        public MyService(IUnityContainer container)
        {
            this.Dependency1 = container.Resolve<Dependency1>();
            //using container directly breaks the dependency chain
            //because I can resolve everything here
            //makes MyService hard to be injected and unit tested 
        }
    }
