    public class RaspberryController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage
            {
                Content = new StringContent("Test from Owin")
            };
        }
    }
