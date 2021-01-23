    static void Main()
    {
        var selector = WiFiDirectDevice.GetDeviceSelector();
 
        var findAllDevicesTask = DeviceInformation.FindAllAsync().AsTask();
        Task.WaitAll(findAllDevicesTask);
        for (var info in findAllDevicesTask.Result)
        {
            ...
        }
    }
