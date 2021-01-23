    using WebApplication1.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    
    namespace WebApplication1.Controllers
    {
        [RoutePrefix("api/books")]
        public class BookController : ApiController
        {
    
            [HttpGet]
            [Route("")]
            public IHttpActionResult ShowAllProducts()
            {
                var db = new DbSearchQuery();
                return Ok(db.LoadBooks());
            }
    
        }
    }
