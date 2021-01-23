    public partial class Drm
    {
        //remove this property
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int DrmId { get; set; }
    
        // one-to-one relation
        [Key, Column(Order = 1), ForeignKey("CustomerSite")]
        public int CustomerSiteId { get; set; }
    
        // one-to-one relation
        [Key,  Column(Order = 2), ForeignKey("Provider")]
        public int ProviderId { get; set; }
    
        // one-to-one relation
        [Key,  Column(Order = 3), ForeignKey("DrmType")]
        public int DrmTypeId { get; set; }
    
        public virtual Provider Provider { get; set; }
        public virtual CustomerSite CustomerSite { get; set; }
        public virtual DrmType DrmType { get; set; }
    }
