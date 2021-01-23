    public class TestController : ApiController {    
        [Route("test/{var1}/{var2}")]
        [AcceptVerbs("POST")]
        public ResultDataType Post(string var1, string var2) {           
            string data = Request.Content.ReadAsStringAsync().Result;
        }
        
        [Route("test2/{id}")] {
        [AcceptVerbs("GET")]
        public string GetData(int id) { 
            return "You requested number " + id;
        }
    }
