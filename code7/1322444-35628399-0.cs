    using Microsoft.AspNet.Mvc;
    using System.Collections.Generic;
    
    namespace External.Controllers
    {
        [Route("api/[controller]")]
        public class NovosController: Controller
        {
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "I am", "an external library" };
            }
        }
    }
