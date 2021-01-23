    public class Membership
    {
     [Key]
     public decimal Id { get; set; }
     [ForeignKey("User")]
     public decimal UserId {get;set;}
     public virtual User User { get; set; }
    }
    public class User
    {
     [Key]
     public decimal Id { get; set; }
     [ForeignKey("Membership ")]
     public decimal MemberShipId {get;set;}
     public virtual Membership Membership { get; set; }
    }
