    public class Instance
    {
        public int InstanceId { get; set; }
        // Still referencing two lists
        public virtual ICollection<User> Users { get; internal set; }
        public virtual ICollection<MasterUser> MasterUsers { get; internal set; }
    }  
    public abstract class CoreUser
    {
        [Key]
        public int UserId { get; set; }
        // No reference to instance. Works if you don't need it from CoreUser
    }
    [Table("Users")]
    public class User : CoreUser
    {
        // FK to Instance defined in CoreUser
        public int InstanceId { get; set; }
        public virtual Instance Instance { get; set; }
        public string UserName { get; set; }
    }
    [Table("MasterUsers")]
    public class MasterUser : CoreUser
    {
        // FK to Instance defined in MasterUser
        public int InstanceId { get; set; }
        public virtual Instance Instance { get; set; }
        public string MasterUserName { get; set; }
    }
