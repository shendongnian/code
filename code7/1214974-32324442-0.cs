    public partial class Device
    {
        [Key]
        public int ID { get; set; }
    
        public int MainPolicyId { get; set; }
        [ForeignKey("MainPolicyId")]
        public virtual Policy MainPolicy { get; set; }
    }
    
    public class Policy
    {
        [Key]
        public override int ID { get; set; }
     
        public int MainDeviceId { get; set; }
       	[ForeignKey("MainDeviceId")]
        public virtual Device MainDevice { get; set; }
    }
