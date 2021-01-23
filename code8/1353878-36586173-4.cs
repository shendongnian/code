    class MyDeviceService
    {
        IObservable<int> VolumeUpdates { get; }
        public async Task SetVolumeAsync(int volume) { }
        public async Task<int> GetVolumeAsync() { }
    }
    // consumer
    _volumeSubscription = myDeviceService.VolumeUpdates
                              .Subscribe(newVolume => Volume = newVolume);
    // deregistration
    // - implicitly, if object gets thrown away (but not deterministic because of GC)
    // - explicitly:
    _volumeSubscription.Dispose();
