    public class DeviceManager
    {
        private Dictionary<Device, Response> behaviours =
            new Dictionary<Device, Behaviour>();
        public DeviceManager()
        {
            Device device = new Device();
            behaviours.Add(device, new Response(device));
        }
    }
