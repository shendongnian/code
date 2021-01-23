    class MyDeviceService : IDeviceService
    {
        public async Task SetVolumeAsync(int volume) { }
        public async Task<int> GetVolumeAsync() { }
    }
    // ViewModel
    class DeviceViewModel : INotifyPropertyChanged
    {
        public int Volume { get{ ... } set { ... } }
        public DeviceViewModel(IDeviceService service) { ... }
    }
