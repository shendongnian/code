    public class AddressDetail : EntityBase {
    //Id from base class
    public virtual ICollection<BPCard> Addresses { get; set; } 
    //public virtual BPCard Addresses { get; set; } 
    public virtual ICollection<HRCard> Addresses { get; set; } 
    //public virtual BPCard Addresses { get; set; } 
    }
