    [Route("api/Simple")] //add this
    public class SimpleController : ApiController
    {
        public string Get()
        {
            return "Hello";
        }
    }
