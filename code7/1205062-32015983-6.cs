    class Foo
    {
        private readonly IDeviceIdProvider _deviceIdProvider;
        public Foo(IDeviceIdProvider deviceIdProvider)
        {
            _deviceIdProvider = deviceIdProvider;
        }
        
        public void DoSomething()
        {
            string deviceId = _deviceIdProvider.GetDeviceId();
            // do something with the device id
        }
    }
...
    var foo = new Foo(new DeviceIdProvider());
