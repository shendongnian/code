    public class User : BaseEntity
    {
        //other attributes
        public virtual ICollection<UserInGroup> UserInGroups { get; set; }
    }
    public class UserInGroup : BaseEntity
    {
        //other attributes
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public virtual User User { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
    public class UserGroup : BaseEntity
    {
        //other attributes
        public string Name { get; set; }
        public string KeyName { get; set; }
    }
