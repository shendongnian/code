    public class SLR : BaseEntity
    {
        public SLR() : base
        {
        }
        // ...
        public virtual ICollection<SLRD> ChildRequests { get; set; }
    }
