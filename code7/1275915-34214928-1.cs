    namespace WebApplication4.Controllers.V2
    {    
        public class ValuesController : ApiController
        {
            
            public IEnumerable<string> Get()
            {
                return new string[] { "value3", "value4" };
            }
        }
    }
