    public class User
    {
        [Key]
        public int UserID {get; set;}
        // other props
    }
    
    public class UserStats
    {
        [Key]
        public int UserStatsID {get; set;}
       
        [ForeignKey("User")]
        public int? UserId {get;set;}
        // other props
        public virtual User User {get; set;}
    }
