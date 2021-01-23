    public partial class ChannelFee
    {
        public virtual ICollection<SubSource> SubSource { get; set; } // Just to enable lazy load
        public int Id { get; set; }
        public string Description { get; set; }
        public string MapName { get; set; }
    }
    public partial class SubSource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string MapName { get; set; }
        public virtual ChannelFee ChannelFee {get; set; } // Navigation property
    }
