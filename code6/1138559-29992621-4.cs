    public class Gift
    {
      public int GiftId { get; set; }
      public int GroupMembershipId { get; set; } //Add this FK property
      public virtual GroupMembership Membership { get; set; }
    }
