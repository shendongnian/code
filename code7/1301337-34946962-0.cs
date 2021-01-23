     [RoutePrefix("api/ndtdocument")]
        public class NDTDocumentsController : ApiController, INDTDocumentsController
        {
            [HttpGet]
            [Route("get")]
            public IHttpActionResult Get()
            {
                var document = Program.NDTServerSession.GetNextNDTDocument(DateTime.Today);
                if (document == null)
                    return null;
        
                return Ok(document);
        
        
            }
        
            [HttpPost]
            [Route("post")]
            public IHttpActionResult Post([FromBody] NDTDocument ndtDocument)
            {
                try
                {
                    Program.NDTServerSession.AddNDTDocument(ndtDocument);
                    return Ok();
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
        
                }   
            }
        }
