    public class User
    {
        public User()
        {
        }
    
        [Key]
        [Column("ID", TypeName ="nvarchar(128)")]
        public string ID { get; set; }
    
        public string Name{ get; set; }
        public virtual UserSetting UserSetting {get;set;} 
    }
    
    public class UserSetting
    {
        public UserSetting()
        {
        }
    
        [Key,ForeignKey("User"),Column("UserID")]
        public string ID { get; set; }
    
        //...
    
        public virtual User User{get;set;}
    }
