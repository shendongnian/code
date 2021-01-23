    public class MyController : ApiController
    {
        // Other actions omitted…
        [AcceptVerbs("Patch")]
        public async Task<IHttpActionResult> Patch(int key, Delta<Item> model)
        {
            var entity = _items.FindAsync(o => o.Id == key);
            if (entity == null) {
                return NotFound();
            }
 
            model.Patch(entity);
            return StatusCode(HttpStatusCode.NoContent);
        }
 
        public async Task<IHttpActionResult> Put(int key, Delta<Item> model)
        {
            var entity = _items.FindAsync(o => o.Id == key);
            if (entity == null) {
                return NotFound();
            }
 
            model.Put(entity);
			
			return StatusCode(HttpStatusCode.NoContent);
        }
    }
