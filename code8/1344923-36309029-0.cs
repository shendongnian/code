    [RoutePrefix("api/vendor")]
    public class VendorController : ApiController
    {
        [Route("ReadVendor"), HttpGet]
        public HttpResponseMessage ReadVendor(int? id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
        //Rest of your code
    }
