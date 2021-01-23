    [Table("tblUsers")]
    public class Users
    {   
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public virtual UserDetail Detail { get; set; }
    }
    
    [Table("tblUserDetails")]
    public class UserDetails
    {
        [Key,ForeignKey("User")]
        public int UserId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    
        public virtual User User { get; set; }
    }
