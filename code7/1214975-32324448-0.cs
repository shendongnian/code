    public partial class Device
    {
        [Key]
        public int ID { get; set; }
        public int MainPolicyId { get; set; }
        public virtual Policy MainPolicy { get; set; }
    }
    
       public class Policy
       {
            [Key]
            public override int ID { get; set; }
            public int MainDeviceId { get; set; }
    
            public virtual Device MainDevice { get; set; }
       }
