    public class Group
    {
      public int GroupId { get; set; }
      public virtual ICollection<GroupMembership> Memberships { get; set; }
    }
    public class GroupMembership
    {
        public int GroupMembershipId { get; set; }
        public virtual ICollection<Gift> Gifts { get; set; }
        public int GroupId {get;set;} //Add this FK property 
        public virtual Group Group { get; set; }
    }
