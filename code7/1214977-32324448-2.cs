    public partial class Device
    {
        [Key]
        public int ID { get; set; }
    
        public int MainPolicyId { get; set; }
        [ForeignKey("MainPolicyId")]
        public virtual Policy SomePolicy { get; set; }
    }
