    public class BaseController : ApiController
    {
        protected Context db = new Context();
    
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
    		
            base.Dispose(disposing);
        }
    }
    
    public class TypeController : BaseController
    {   
        [Route("GetMapData")]
        public async Task<IHttpActionResult> GetMapData()
        {
            var result = await db.Types
                                 .Select(e => new
                                 {
                                     Id = e.TypeId,
                                     Name = e.Name
                                 })
                                 .ToListAsync();
            return Ok(result);
        }  
    }
