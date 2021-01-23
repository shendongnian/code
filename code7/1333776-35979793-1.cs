    [RoutePrefix("api/tests")]
    public class TestsController : ApiController {
        [HttpPost]
        [Route("")]
        public async Task<string> Post() {
            var content = await Request.Content.ReadAsStringAsync();
            return content;
        }
    }
