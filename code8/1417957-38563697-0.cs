    public class GraminController : ApiController
    {
        // GET
        [HttpGet]
        [Route("api/garmin/data")]
        public string GetGarminData()
        {
            return "API does not support data retrieval";
        }
    }
