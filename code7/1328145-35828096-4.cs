    public class OfficeDetailsController : ApiController {    
        public IHttpActionResult GetOfficeDetails(int id) {
            var item = new OfficeDetailsDto() { Id = id, Name = "Gizmo"};
            // what ever else needs to be done to the item
            // ...    
            return Ok(item);
        }
    }
