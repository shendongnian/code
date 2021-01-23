    public class DeviceController : Controller {
        //GET device/2/isvalid
        [HttpGet]
        [Route("Device/{id}/IsValid")]
        public bool IsValid(int id) {
            return true;
        }
    }
