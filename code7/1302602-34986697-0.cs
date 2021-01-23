    public abstract class Factory<TDevice> where TDevice : Device
    {
        public abstract IEnumerable<TDevice> DeviceCollection { get; }
        public abstract void Add(TDevice added);
        public void ListDevices() 
            { 
                foreach (var item in DeviceCollection) 
                    Debug.WriteLine($"Device: {item.Name}"); 
            }
    }
