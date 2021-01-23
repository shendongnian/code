    public class OrderController : ApiController {    
        //GET api/Order/saywhat/33
        [System.Web.Http.HttpGet]
        public string SayWhat(string quote) {
            return "Hello World " + quote;
        }
    }
