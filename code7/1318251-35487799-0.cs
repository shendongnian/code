    public class TestController : ApiController
    {
        public IHttpActionResult TestMethod([FromUri]Input input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //other code
            return Ok();
        }
    }
    public class Input
    {
        [Range(1, 50, ErrorMessage = "Error Message")]
        public int testParamFromUri { get; set; }
    }
