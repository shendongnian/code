    public class BaseController : ApiController
    {
       // ...
       public IHttpActionResult MethodA(int id)
       {
           var foo = repository.Get(id);
           if (foo == null)
               return NotFound();
    
           return Ok(foo);
       }
    }
    
    public class ControllerA : BaseController
    {
       //...
    }
    
    public class ControllerB : BaseController
    {
       public IHttpActionResult MethodB(int id)
       {
           var result = MethodA();
           //..
       }
    }
