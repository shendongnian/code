    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;
    
    namespace SampleWebApi.Controllers
    {
        // You have to Add this One line in your API Controller
        [EnableCors(origins: "*", headers: "*", methods: "*")] // Allow CORS for all origins. (Caution!)
        public class ValuesController : ApiController
        {
            // GET api/values
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
    
            // GET api/values/5
            public string Get(int id)
            {
                return "value";
            }
        }
    }
