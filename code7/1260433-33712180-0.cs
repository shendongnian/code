    public class UserInfo
    {
        // other codes here
        public string UserID {get;set;}
        public virtual ApplicationUser User {get;set;}    
    }
    public class ApplicationUser: IdentityUser
    {
        // other properties
        public int InfoID {get;set;}
        public virtual UserInfo Info {get;set;}
    }
