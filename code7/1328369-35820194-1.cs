    using Microsoft.AspNet.Mvc;
    using System.Collections.Generic;
    
    namespace WebApplication5.Controllers
    {
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            private IStudentDataAccess _studentDataAccess;
    
            public ValuesController(IStudentDataAccess studentDataAccess)
            {
                _studentDataAccess = studentDataAccess;
            }
    
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "value", _studentDataAccess.Hello() };
            }
        }
    }
