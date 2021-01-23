    public partial class DriversToVehicle
    {
        [Column("id"), Key]
        public int ID { get; set; }
        [Column("driverid")]
        public int DriverID { get; set; }
        [ForeignKey("DriverID")]
        public Driver Driver { get; set; }
        [Column("DriverType")]
        public int DriverType { get; set; }
        [ForeignKey("type")]
        public int DriverType { get; set; }
        [Column("vehicleid")]
        public int VehicleID { get; set; }
        [ForeignKey("VehicleID")]
        public Vehicle Vehicle { get; set; }
    }
