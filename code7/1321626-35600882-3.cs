        using System;
    
    namespace WpfApplication
    {
        public interface IDeviceInformationVM
        {
            string MyProperty { get; set; }
        }
    
        public class DeviceInformationVM : IDeviceInformationVM
        {
            public string MyProperty
            {
                get; set;
            }
        }
    }
