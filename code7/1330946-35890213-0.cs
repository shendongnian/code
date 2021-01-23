    configuration.MapHttpAttributeRoutes();
    
    public class DataOperationController : ApiController
    {
            DataOperationManager dalManager = new DataOperationManager();
            [HttpPost, Route("api/users/add")]
            public User AddUser(User user)
            {
                User newUser = new NBFTestModels.Models.User();
                newUser = dalManager.AddUser(user);
                return newUser;
            }
    
            [HttpPost, Route("api/devices/add")]
            public Device AddDevice(Device device)
            {
                Device newDevice = new NBFTestModels.Models.Device();
                newDevice = dalManager.AddDevice(device);
                return newDevice;
            }
    }
