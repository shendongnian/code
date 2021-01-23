    class DeviceWrapperFactory
    {
        public static DeviceWrapper Connect(Device device)
        {
            if (!_device.IsConnected)
            {
                // assume trying to reconnect here if possible
                // like "if (!device.TryToConnect())"
                throw new DeviceConnectionFailedException();
            }
            return new DeviceWrapper(_device);
        }
    }
    class DeviceWrapper
    {
        private Device device;
    
        DeviceWrapper(Device device)
        {
            _device = device;
        }
        public string Name
        {
            get
            {
                return device.getParameter("Name");
            }
        }
    }
