    [RoutePrefix("api")]
    public class RegistrationController : ApiController
    {
        [Route("registration")]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
    
            return response;
        }
    
        [Route("registration/{pilotId:int}")]
        public HttpResponseMessage Get(int pilotId)
        {
            var response = new HttpResponseMessage();
            
            //Your code goes here...
            return response;
        }
    }
