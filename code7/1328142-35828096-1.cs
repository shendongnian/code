    public class OfficeDetailsController : BaseAPIController {
    
        public HttpResponseMessage GetOfficeDetails(int id) {
            var item = new OfficeDetailsDto() { Id = id, Name = "Gizmo"};
            // what ever else needs to be done to the item
            // ...    
            return NegotiatedContent(HttpStatusCode.Ok, item);
        }
    }
