    [RoutePrefix("api/MyController")]
    public class MyController : ApiController
    {
       [HttpDelete]
       [Route("{id:int}", Order = 1)]
       public IHttpActionResult Delete(int id) {..}
    
       [HttpDelete]
       [Route("{id:guid}", Order = 2)]
       public IHttpActionResult Delete2(Guid id) {..}
    
       [HttpDelete]
       [Route("{id}", Order = 3)]
       public IHttpActionResult Delete3(string id) {..}
    
    }
