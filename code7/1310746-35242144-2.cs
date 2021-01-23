    public class Setting
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        [MaxLength(512)]
        public string Value { get; set; }
        public bool IsPassword { get; set; }
        //Add these properties
        public int ForeignId{ get; set; }
        public virtual Monitor Monitor { get; set; }
        public virtual Notifier Notifier { get; set; }
    }
    public class Notifier
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public List<Setting> Settings { get; set; }
        
        //Add these properties
        public int MonitorId { get; set; }
        public virtual Monitor Monitor { get; set; }
    }
