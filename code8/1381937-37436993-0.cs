    public class MyController : ApiController
    {
       [HttpDelete]
       [Route("api/MyController/{id:int}", Order = 1)]
       public IHttpActionResult Delete(int id) {..}
    
       [HttpDelete]
       [Route("api/MyController/{id:guid}", Order = 2)]
       public IHttpActionResult Delete2(Guid id) {..}
    
       [HttpDelete]
       [Route("api/MyController/{id}", Order = 3)]
       public IHttpActionResult Delete3(string id) {..}
    
    }
