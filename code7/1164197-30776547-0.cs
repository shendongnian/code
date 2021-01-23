    public class ContentFile
        {
            public int ID { get; set; }
        }
    
        public class ContentFilesController : ApiController
        {
            [Route("api/contentfile/{count}")] //this one works
            [Route("api/contentfile/{id}")] //this one does not work
            [HttpGet]
            public IHttpActionResult GetContentFiles(int count)
            {
                var files = new List<ContentFile>();
                for (int x = 0; x < count; x++)
                {
                    files.Add(new ContentFile(){ID=x});
                }
    
                return Ok(files);
            }
        }
