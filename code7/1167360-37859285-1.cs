    public class BooksController : System.Web.Http.ApiController {
    
        [System.Web.Http.HttpPut]
        public HttpResponseMessage Update([FromBody] BookInformation bookStatus) {
          // Stuff...
        
          // Retrieve clients IP#
          var clientIp = Request.GetClientIpString();
        }
    }
