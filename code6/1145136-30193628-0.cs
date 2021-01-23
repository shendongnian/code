    public partial class Product {
        [Key, Column(Order = 0)]
        public virtual string OrderNumber { get; set; }
        [Key, Column(Order = 1)]
        public virtual int? VersionNumber { get; set; }
        [Key, Column(Order = 2)]
        public virtual string SocialNumber { get; set; }
    }
    public partial class Delivery {
        [Key, Column(Order = 0), ForeignKey("Product")]
        public virtual string OrderNumber { get; set; }
        [Key, Column(Order = 1), ForeignKey("Product")]
        public virtual int? VersionNumber { get; set; }
        [Key, Column(Order = 2), ForeignKey("Product")]
        public virtual string SocialNumber { get; set; }
    }
