    [EnableCors("AllowAll")]
    [Route("api/exampleController")]
    public class exampleController : Controller
    {  
       ...
     [HttpPost]
     [Route("add")]
     public object Add(string title, string myStruct)
     {
      ...
     }
    }
