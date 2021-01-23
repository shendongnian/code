    public class TestController : ApiController
        {
                [EnableCors(origins: "*", headers: "*", methods: "*")]
                public string Get()
                {
                    return "Hello world";
                }
       }
