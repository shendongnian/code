    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
    
        [MaxLength(20)]
        public string VehicleNumber { get; set; }
    
        public int? VehicleOwnerID { get; set; }
        [ForeignKey("VehicleOwnerID")]
        public virtual Person VehicleOwner { get; set; }
    
        public int? VehicleDriverID { get; set; }
        [ForeignKey("VehicleDriverID")]
        public virtual Person VehicleDriver { get; set; }
    
        public int? PersonID { get; set; }
        [ForeignKey("PersonID")]
        public virtual Person Person { get; set; }
    
    }
