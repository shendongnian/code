    public class TestController : ApiController {    
        [Route("test/{username}/{password}")]
        [AcceptVerbs("POST")]
        public string Post(string username, string password) {  
            if(username == "user" && password == "pass") {  // check user/pass
                 string data = Request.Content.ReadAsStringAsync().Result;
                 //do something
                 return "User is authenticated";
            }
        }
        
        [Route("test2/{id}")] {
        [AcceptVerbs("GET")]
        public string GetData(int id) { 
            return "You requested number " + id;
        }
    }
