    [RoutePrefix("device")]
    public class DeviceController : Controller {
        //GET device/2/isvalid
        [HttpGet]
        [Route("{id:int}/IsValid")]
        public bool IsValid(int id) {
            return true;
        }
    }
