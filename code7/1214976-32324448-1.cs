    public partial class Device
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("MainPolicy")]
        public int CurrentPolicyId { get; set; }
        public virtual Policy MainPolicy { get; set; }
    }
