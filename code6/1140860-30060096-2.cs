    public class FeedbackController : ApiController
    {
        // GET: api/Feedback
        public IEnumerable<Feedback> Get()
        {
            return new Feedback[] { new Feedback(), new Feedback() };
        }
        // GET: api/Feedback/5
        public Feedback Get(int id)
        {
            return new Feedback();
        }
        // POST: api/Feedback
        public IHttpActionResult Post([FromBody]Feedback value)
        {
            return Ok(value);
        }
        // PUT: api/Feedback/5
        public IHttpActionResult Put(int id, [FromBody]Feedback value)
        {
            return Ok(value);
        }
        // DELETE: api/Feedback/5
        public void Delete(int id)
        {
        }
    }
