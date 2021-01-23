    //[Authorize]
    [RoutePrefix("api/Graph")]
    public class GraphController : ApiController
    {
        // POST: api/Graph
        [Route("LoadGraph", Name = "LoadGraph")]
        public IHttpActionResult LoadGraph([FromBody] string text)
        {
            RecursiveGraph result = test.SecondMethodFruchterman(text);
            return Ok(result);
        }
    }
