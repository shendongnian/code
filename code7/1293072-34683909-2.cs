    public class Device
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceId { get; set; }
    
        public int? DefaultPrinterId { get; set; }
    
        public virtual Printer DefaultPrinter { get; set; }
        //that's new
        public virtual ICollection<Printer> PrintersThatLoveMe { get; set; }
    }
    
    public class Printer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrinterId { get; set; }
    
        public int? DeviceId { get; set; }
    
        public virtual Device Device { get; set; }
        //that's new
        public virtual ICollection<Device> DevicesThatLoveMe { get; set; }
        
    }
