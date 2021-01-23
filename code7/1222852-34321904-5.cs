    [RoutePrefix("api/Movie")]
    public class MovieController : ApiController
    {
        IMovieRepository repo;
         
        public MovieController(IMovieRepository _repo)
        {
            this.repo = _repo;
        }
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
