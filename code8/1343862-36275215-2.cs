    [RoutePrefix("api/users")]
    public class UserController: ApiController {
        //eg: GET api/users?firstname={firstname}&lastname={lastname}
        [HttpGet]
        [Route("")]
        public User Get([FromUri]string firstname,[FromUri] string lastname) {...}
        //eg: GET api/users/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public User Get(Guid id){...}
        //eg: GET api/users/{id}/friends
        [HttpGet]
        [Route("{id:guid}/friends")]
        public IEnumerable<User> Friends(Guid id){...}
        //eg: GET api/users/{id}/followers
        [HttpGet]
        [Route("{id:guid}/followers")]
        public IEnumerable<User> Followers(Guid id){...}
        //eg: GET api/users/{id}/favorites
        [HttpGet]
        [Route("{id:guid}/favorites")]
        public IEnumerable<User> Favorites(Guid id){...}
    }
