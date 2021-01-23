    public abstract partial class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public FirstName { get; set; }
        public string LasName { get; set; }
        public Genders Gender { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string TechUser { get; set; }
        public DateTime TechChangeDate { get; set; }
        public int TechVersion { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<UserInGroup> UserInGroups { get; set; }
    }
    public class UserInGroup : BaseEntity
    {
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public string TechUser { get; set; }
        public DateTime TechChangeDate { get; set; }
        public int TechVersion { get; set; }
        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
    public class UserGroup : BaseEntity
    {
        public string Name { get; set; }
        public string KeyName { get; set; }
        public string TechUser { get; set; }
        public DateTime TechChangeDate { get; set; }
        public int TechVersion { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class Role : BaseEntity
    {
        public string Name { get; set; }
    }
    public enum Genders 
    {
        Male = 1,
        Female = 2
    }
    
