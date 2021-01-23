    [RoutePrefix("api")]
    public class DefCurrencyController : ApiController
    {
        [Route("currencies")]
        public HttpResponseMessage Get()
        {
           return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
