    class FakeDeviceIdProvider : IDeviceIdProvider
    {
        private string _deviceId = Guid.NewGuid().ToString();
        public string GetDeviceId()
        {
            return _deviceId;
        }
    }
