    class MyDeviceService
    {
        public static string VolumeMessageKey = "Volume";
        public async Task SetVolumeAsync(int volume) { }
        public async Task<int> GetVolumeAsync() { }
        // producer
        MessagingCenter.Send<MyDeviceService, int>(this, 
            VolumeMessageKey, newVolume);
    }
    // consumer
    MessagingCenter.Subscribe<MyDeviceService, int>(this, 
         MyDeviceService.VolumeMessageKey, newVolume => Volume = newVolume);
    // needs deregistration
    MessagingCenter.Unsubscribe<MyDeviceService, int>(this, 
        MyDeviceService.VolumeMessageKey, newVolume => Volume = newVolume);
