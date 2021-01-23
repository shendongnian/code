    [RoutePrefix("api/titleestimate")]
    public class TitleEstimateController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTitleEstimate([FromUri] EstimateQuery query)
        {
                // All the values in "query" are null or zero
                // Do some stuff with query if there were anything to do
        }
    }
