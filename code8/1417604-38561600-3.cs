    public class TestController : ApiController
    {
        public IHttpActionResult Post(FileData data)
        {
            return this.Ok(data);
        }
    }
