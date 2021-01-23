    [RoutePrefix("api")]
    public class MyController : ApiController
    {
        [HttpGet]
        [Route("My/{id1:guid}/{id2:guid}")]
        public object Get(Guid id1, Guid id2)
        {
            return new object();
        }
    }
