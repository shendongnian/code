	public class DeviceManagerFactory : IDeviceManagerFactory {
		private readonly IDeviceConfigurationRepository _repository;
		public DeviceManagerFactory(IDeviceConfigurationRepository repository) {
			_repository = repository;
		}
		public DeviceManager Create(int minutes) {
			return new DeviceManager(_repository, minutes);
		}
	}
