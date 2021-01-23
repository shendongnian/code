    [AttributeUsage(AttributeTargets.All)]
    public class DeviceInformationAttribute : Attribute
    {
        public DeviceInformationAttribute(string description, string value)
        {
            this.Description = description;
            this.Value = value;
        }
        public string Description { get; set; }
        public string Value { get; set; }
    }
