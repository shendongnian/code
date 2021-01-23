    public class DeviceType
    {
        public static readonly DeviceType
            Stb = new DeviceType("Stb", "Set Top Box", 19.95),
            Panel = new DeviceType("Panel", 99),
            Monitor = new DeviceType("Monitor", 19.95),
            Cable = Simple("Cable"),
            Connector = Simple("Connector"),
            WirelessKeyboard = new DeviceType("WirelessKeyboard", "Wireless Keyboard", 20);
    
        private static readonly IEnumerable<DeviceType> _all = typeof(DeviceType)
            .GetFields(BindingFlags.Public | BindingFlags.Static).Select(f => (DeviceType)f.GetValue(null)).ToArray();
        public static IEnumerable<DeviceType> All { get { return _all; } }
    
        public static DeviceType Parse(string name)
        {
            foreach (var item in All)
            {
                if (item.Name == name)
                    return item;
            }
            throw new KeyNotFoundException(name);
        }
        private static DeviceType Simple(string name)
        {
            return new DeviceType(name, name, 9.95);
        }
        private DeviceType(string name, decimal value) : this(name, name, value) { }
        private DeviceType(string name, string description, decimal value)
        {
            Name = name;
            Description = description;
            Value = value;
        }
    
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public override string ToString()
        {
            return Name;
        }
    }
