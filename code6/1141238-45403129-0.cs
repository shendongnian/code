    [RoutePrefix("api")]
    public abstract class BaseController : ApiController
    {
    }
    [RoutePrefix("values")]
    public class ValuesController : BaseController
    {
        [Route("{id}")]
        public int Get(int id)
        {
            return id;
        }
    }
