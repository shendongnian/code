    interface IAuditableEntity
    {
        int CreatedBy {get; set;}
        int ModifiedBy {get; set;}
    }
    public class Product : IAuditableEntity
    {
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public int CreatedBy {get; set;}
        public int ModifiedBy {get; set;}
    }
    public class Vendor : IAuditableEntity
    {
        public string VendorName{ get; set; }
        public string VendorNumber { get; set; }
        public int CreatedBy {get; set;}
        public int ModifiedBy {get; set;}
    }
