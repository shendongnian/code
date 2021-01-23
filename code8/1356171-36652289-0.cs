    public class Registry {
        private readonly RegistryManager _registryManager;
        public Registry(RegistryManager rm) {
            _registryManager = rm;
        }
        public async Task<string> GetDeviceKey(string deviceId = null) {
            if (deviceId == null) {
                throw new Exception("Todo replace");
            }
            var device = await _registryManager.GetDeviceAsync(deviceId);
            if (device == null) {
                throw new Exception("TODO replace");
            }
            return device.Authentication.SymmetricKey.PrimaryKey;
        }
    }
