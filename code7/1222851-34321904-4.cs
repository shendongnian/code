        [RoutePrefix("api/Movie")]
        public class MovieController : ApiController
        {
            [Route("latest")]
            [HttpGet]
            public IHttpActionResult Get()
            {
                try
                {
                    //var getAllMovies = repo.GetAll();
                    return Ok("hello");
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }
        }
