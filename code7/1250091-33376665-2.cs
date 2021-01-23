    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
    
        public virtual UserActivation UserActivation { get; set; }
    }
    
    public class UserActivation
    {
        [Key]
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public bool Active { get; set; }
    
        public virtual User User { get; set; }
    }
