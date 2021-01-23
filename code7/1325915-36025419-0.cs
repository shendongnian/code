    [RoutePrefix("api/movies")]
    public class MoviesAPIController : ApiController {
    
        IMovieRepository repository;
    
        public MovieController(IMovieRepository repository) {
            this.repository = repository;
        }
    
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(MovieDTO))]
        public IHttpActionResult Get(int id) {
            var movie = repository.GetById(id);
            if (movie == null) {
                return NotFound();
            }
            return Ok(movie);
        }
    
        // POST api/movies
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(MovieDTO))]
        public IHttpActionResult PostMovies(MovieDTO movie) {
    
            // Validation
            if (String.IsNullOrWhiteSpace(movie.Title)) {
                return BadRequest("Movie Title is required");
            }
    
            if (movie.GenreIds == null || movie.GenreIds.Count == 0) {
                return BadRequest("A new Movie requires at least one genre to be selected");
            }
    
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
    
            repository.Add(movie);
            return CreatedAtRoute("DefaultApi", new { id = movie.Id, title = movie.Title }, movie);
        }
    
        public IHttpActionResult Delete(int id) {
            repository.Delete(id);
            return Ok();
        }
    
        public IHttpActionResult Put(MovieDTO movie) {
            // Do some work (not shown).
            return Content(HttpStatusCode.Accepted, movie);
        } 
    }
