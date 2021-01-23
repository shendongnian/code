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
    
        public virtual IEnumerable<InsurancePolicy> PoliciesAsList { get; set; }
        [NotMapped]
        public virtual InsurancePolicy Policy {
            get {
                return (PoliciesAsList != null) 
                    ? PoliciesAsList.FirstOrDefault() 
                    : null;                
            }
        }
    
    }
