    private async Task<GattDeviceService> GetGATTServiceAsync(string deviceName)
    {
      //devicewatcher is abused to trigger connection
      var deviceWatcher = DeviceInformation.CreateWatcher(); //trick to enable GATT
    
      var addedSource = Observable.FromEventPattern(deviceWatcher, nameof(deviceWatcher.Added))
                                  .Select(pattern => ((DeviceInformation)pattern.EventArgs));
    
      var updatedSource = Observable.FromEventPattern(deviceWatcher, nameof(deviceWatcher.Updated))
                                    .Select(pattern =>
                                    {
                                      var update = ((DeviceInformationUpdate)pattern.EventArgs);
                                      return Observable.FromAsync(() => DeviceInformation.CreateFromIdAsync(update.Id).AsTask());
                                    }).Concat();
    
      var source = addedSource.Merge(updatedSource);
      source.Publish().Connect(); //make sure the event handlers are attached before starting the device watcher
    
      deviceWatcher.Start();
    
      var result = await source.Where(di =>  di.Name == deviceName)                                       //find the relevant device
                               .Select(di => Observable.FromAsync(() => GattDeviceService.FromIdAsync(di.Id).AsTask()))       //get all services from the device
                               .Concat()                                                                                      //necessary because of the async method in the previous statement
                               .Where(service => service.Uuid == SERVICE_UUID)                                                //get the service with the right UUID
                               .Retry()                                                                                       //GattDeviceService.FromIdAsync can throw exceptions
                               .FirstAsync();
    
      deviceWatcher.Stop();
    
      return result;
    }
