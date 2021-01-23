    public class DeviceV1Controller : ApiController
    {
        private readonly IDevice _repository;
        public DeviceV1Controller()
        {
            _repository = new EFDeviceRepository();
        }
        // ...
    }
