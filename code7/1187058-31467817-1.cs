    public class DriverHandlerAttribute : Attribute
    {
        public Type DriverType { get; set; }
        public string ConfigurationName { get; set; }
    }
