    public class User : IdentityUser
    {
        public User()
        {
            // Don't do this. Entity Framwork will do that for you
            // Followers = new HashSet<Following>();
            // Following = new HashSet<Following>();
        }
    
        // Don't add this. IdentityUser has already defined it as `Id`
        // [Key]
        // public string ID { get; set; }
    
        public virtual ICollection<Following> Followers { get; set; }
    
        public virtual ICollection<Following> Following { get; set; } 
    }
    
    public class Following
    {
        [Key]        
        public int ID {get;set;}
    
        // [MaxLength(100)] No need to do this as this is Foreign Key Property
        public string follower { get; set; }
    
        // [MaxLength(100)] No need to do this as this is Foreign Key Property
        public string following { get; set; }           
    
        public virtual User UserFollower { get; set; }
    
        public virtual User UserFollowing { get; set; }
    }
