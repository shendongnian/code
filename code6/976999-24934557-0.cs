    using System.Collections.Generic;
    using System.IO.Compression;
    using System.Web;
    using System.Web.Http;
    
    namespace MvcApplication1.Controllers
    {
        public class ValuesController : ApiController
        {
            public class Person
            {
                public string Name { get; set; }
            }
            // GET api/values
            public IEnumerable<string> Get()
            {
                return new [] { "value1", "value2" };
            }
    
            // GET api/values/5
            public Person Get(int id)
            {
                HttpContext.Current.Response.Filter = new GZipStream(HttpContext.Current.Response.Filter, CompressionLevel.Optimal);
                HttpContext.Current.Response.AddHeader("content-encoding", "gzip");
                HttpContext.Current.Response.Cache.VaryByHeaders["accept-enconding"] = true;
                return new Person { name = "daniel" };
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
