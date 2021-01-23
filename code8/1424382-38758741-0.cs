    public class ValuesController : ApiController
    {
        [EnableQuery]
        public IQueryable<string> Get()
        {
            return new string[] { "value1", "value2","values3","values4" }.AsQueryable<string>();
        }
    }
