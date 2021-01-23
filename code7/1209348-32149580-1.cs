    public class User
    {
        [Key]
        public int UserID {get; set;}
        // other props
    }
    
    public class UserStats
    {
        [Key, ForeignKey("User")]
        public int UserID {get; set;}
        // other props
    
    
        public virtual User User {get; set;}
    }
