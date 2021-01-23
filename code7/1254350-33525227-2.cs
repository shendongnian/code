    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Routing;
    
    namespace MvcApplication2.Controllers
    {
        public class TestClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    
        [RoutePrefix("prefix")]
        public class ValuesController : ApiController
        {
            // GET api/values
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }
    
            // GET api/values/5
            [Route("{id}/methodname")]
            public string Get(int id, [FromUri] TestClass objectFromUri)
            {
                return "value";
            }
    
            // POST api/values
            public void Post([FromBody]string value)
            {
            }
    
            // PUT api/values/5
            public void Put(int id, [FromBody]string value)
            {
            }
    
            // DELETE api/values/5
            public void Delete(int id)
            {
            }
        }
    }
