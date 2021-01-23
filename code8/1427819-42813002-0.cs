    public class Login
    {
        public int TeamMemberId { get; set; }
        public virtual TeamMember TeamMember { get; set; }
    }
    
    public class TeamMember
    {
        [NotMapped]
        public virtual Login Login
        {
            get { return Logins.FirstOrDefault(); }
        }
    
        public virtual ICollection<Login> Logins { get; set; }
    }
    
