    using System.Web.Http;
    using Newtonsoft.Json;
    
    namespace WebApplication3.Controllers
    {
        public class ValuesController : ApiController
        {
            [HttpPost]
            public string Post([FromBody]MyModel value)
            {
                return value.FirstName.ToUpper();
            }
        }
    
        public class MyModel
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
        }
    }
