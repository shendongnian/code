    class MyDeviceService
    {
        public Action<int> VolumeChangedCallback { get; set; }
        public async Task SetVolumeAsync(int volume) { }
        public async Task<int> GetVolumeAsync() { }
        // producer
        VolumeChangedCallback(newVolume);
    }
    // consumer
    myDeviceService.VolumeChangedCallback = v => Volume = v;
    // deregistration
    myDeviceService.VolumeChangedCallback = null;
