    public class InsurancePolicy : AuditableEntity<int>
    {   
        [Column("id"), Key]
        public override int ID { get; set; }
        [Column("deviceid"), ForeignKey("Device")]
        public int DeviceId { get; set; }
        public virtual Device Device { get; set; }
    }
    
    public partial class Device : AuditableEntity<int>
    {
        [Column("deviceid"), Key]
        public override int ID { get; set; }
    
        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        public virtual InsurancePolicy Policy { get; set; }
    
    }
