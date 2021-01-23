    public class MyController : ApiController
     {
            [Route("api/DoSomething/")]
            [HttpGet]
            public bool DoSomething(string param)
            {
                 //Do Something...
            }
      }
