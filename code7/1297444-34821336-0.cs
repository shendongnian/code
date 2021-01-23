    public class Device
            {
                private List<DeviceBase> _deviceInfo = new List<DeviceBase>();
                private List<Warranty> _warrantyInfo = new List<Warranty>();
    
                public List<DeviceBase> DeviceInfo
                {
                    get
                    { return _deviceInfo; }
                    set
                    { _deviceInfo = value; }
                }            
                public List<Warranty> WarrantyInfo
                {
                    get
                    { return _warrantyInfo; }
                    set
                    { _warrantyInfo = value; }
                }
            }
            
            public class DeviceBase
            {
                public string Product { get; set; }
                public string OrderNumber { get; set; }
                public string ServiceTag { get; set; }
                public string ShipDate { get; set; }
    
            }
            public class Warranty
            {
                public string Service { get; set; }
                public string Provider { get; set; }
                public string StartDate { get; set; }
                public string EndDate { get; set; }
                public string TypeOfWarranty { get; set; }
            }
