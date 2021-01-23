    class MyDeviceService
    {
        public event EventHandler<VolumeChangedEventArgs> VolumeChanged;
        public async Task SetVolumeAsync(int volume) { }
        public async Task<int> GetVolumeAsync() { }
        // producer
        VolumeChanged(new VolumeChangedEventArgs(newVolume));
    }
    // consumer
    MessagingCenter.Subscribe<MyDeviceService, int>(this, 
         MyDeviceService.VolumeMessageKey, newVolume => Volume = newVolume);
    // needs deregistration
    MessagingCenter.Unsubscribe<MyDeviceService, int>(this, 
        MyDeviceService.VolumeMessageKey, newVolume => Volume = newVolume);
