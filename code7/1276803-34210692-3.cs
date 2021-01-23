    public partial class PurchaseOrder
    {
        public int Id { get; set; }  // Should not be virtual
        public int PCodeId { get; set; } // Should not be virtual
        public virtual PCode PCode { get; set; } // new Navigation
    }
    public partial class PCode
    {
        public int Id { get; set; }  // Should not be virtual
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; } // new Navigation
    }
