    public class DatesController : ApiController
    {
        [HttpGet]
        [Route("api/dates/{take:int?}")]
        public IHttpActionResult GetDates(int take = 0)
        {
            return Ok(new
            {
                Date = "11/05/2016"
            });
        }
    }
