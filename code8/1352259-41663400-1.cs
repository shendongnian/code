    [RoutePrefix("api/tests")]
    [AllowAnonymous]
    public class TestsApiController : WebApiControllerBase {
        [HttpGet]
        [Route("{lat:double:range(-90,90)}/{lng:double:range(-180,180)}", Name = "TestsApi_Get")]
        public object Get(double lat, double lng) {
            return new { lat = lat, lng = lng };
        }
    }
