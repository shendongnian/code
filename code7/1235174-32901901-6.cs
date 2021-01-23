     [AttributeUsage(AttributeTargets.All)]
    public class DeviceInformationAttribute : Attribute
    {
        public DeviceInformationAttribute(string description)
        {
            this.Description = description;
        }
        public DeviceInformationAttribute(decimal value)
        {
            this.Description = string.Empty;
            this.Value = value;
        }
        public DeviceInformationAttribute(string description, decimal value)
        {
            this.Description = description;
            this.Value = value;
        }
      
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
