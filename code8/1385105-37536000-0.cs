    public class UsersController : ApiController {
    
        [HttpPut]
        [Route("api/Users")]
        public IHttpActionResult Put(User user) {
            try {
                //assuming some form of storage for models
                repository.Users.Update(user);
                return Ok();
            } catch (Exception) {
                return NotFound();
            }
        }
    }
