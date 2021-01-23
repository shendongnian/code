    public class TitleEstimateController : ApiController
    {
        public class EstimateQuery
        {
            public string username { get; set; }
        }
        
        public IHttpActionResult GetTitleEstimate([FromUri] EstimateQuery query)
        {
            // All the values in "query" are null or zero
            // Do some stuff with query if there were anything to do
            if(query != null && query.username != null)
            {
                return Ok(query.username);
            }
            else
            {
                return Ok("Add a username!");
            }
        }        
    }
