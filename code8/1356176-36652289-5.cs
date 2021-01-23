    public class ActualRegistryManager : IRegistryManager {
        private readonly RegistryManager _registryManager
    
        public ActualRegistryManager (RegistryManager manager) {
            _registryManager = manager;
        }
    
        public Task<Device> GetDeviceAsync(string deviceId) {
            return _registryManager.GetDeviceAsync(deviceId);
        }
    }
