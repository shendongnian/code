    public class InsurancePolicy : AuditableEntity<int>
    {
        [Column("deviceid"), Key, ForeignKey("Device")]
        public override int ID { get; set; }
        public virtual Device Device { get; set; }
    }
    
    public partial class Device : AuditableEntity<int>
    {
        [Column("deviceid"), Key]
        public override int ID { get; set; }
    
        public virtual InsurancePolicy Policy { get; set; }    
    }
