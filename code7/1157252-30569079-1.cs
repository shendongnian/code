    public class ControllerA : ApiController
    {
       private IFooService fooService;
       public ControllerA(IFooService fooService)
       {
           this.fooService = fooService;
       }
       public IHttpActionResult MethodA(int id)
       {
          // use fooService.Method()
       }
    }
    
    public class ControllerB : ApiController
    {
       private IFooService fooService;
       public ControllerB(IFooService fooService)
       {
           this.fooService = fooService;
       }
       public IHttpActionResult MethodB(int id)
       {
            // use fooService.Method()
       }
    }
