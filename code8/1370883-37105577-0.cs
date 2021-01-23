    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AllowedDeviceTypesAttribute : System.Attribute
    {
        //...
        public override object TypeId
        {
            get
            {
                return this;
            }
        }
    }
