    public class FoldersController : ApiController 
    {
        [HttpGet]
        [Route("api/folders/")]
        public string GetThis(DateTime queryStringDate) 
        {
            return "abc";
        }
        [HttpGet]
        [Route("api/folders/{furtherpath}")]
        public bool GetThat(string furtherpath) 
        {
            return "xyz";
        }
    }
