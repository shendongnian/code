    public class Device
    {
          [Key]
        public int Id { get; set; }
        public ICollection<Connection> Slaves { get; set; }
    }
    public class Connection
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Master")]
        public int MasterDeviceId { get; set; }
        [ForeignKey("Slave")]
        public int SlaveDeviceId { get; set; }
        public virtual Device Master { get; set; }
        public virtual Device Slave  { get; set; }
        public DateTime       Start  { get; set; }
        public DateTime       End    { get; set; }
    }
