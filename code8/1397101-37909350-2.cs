    namespace WebApi2.Controllers
    {
        [RoutePrefix( "api/Dummies" )]
        public class Dummy : ApiController
        {
            //GET api/dummies/dummymethod
            [HttpGet]
            [Route("dummymethod")]
            public string Get()
            {
                return "asdasd";
            }
        }
    }
