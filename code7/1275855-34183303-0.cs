    public partial class Web_Vendor
    {  
        public string VendorID { get; set; }
        public virtual Deal_Brands DealBrand { get; set; }
    }
     public partial class Deal_Brands
     {    
        public string VendorID { get; set; }   
        public string Brand { get; set; }
        public virtual Web_Vendor WebVendor { get; set; }    
     }
