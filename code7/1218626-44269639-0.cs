    public class MyController : ApiController
      {
        private static readonly ILog Log = LogManager.GetLogger<MyController>();
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
          Log.Debug("Called Get with id " + id.ToString());
          return Ok();
        }
      }
