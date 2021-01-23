    public class UserProfile
    {
        //UserProfile does not have its own Id,
        //Its Id is the LoginId, which is the primary key and a foreign key
        //It ensures the 1:1 relationship
        public int LoginId { get; set; } // PK and FK
        // some properties omitted
        public Login Login { get; set; }
    }
    public class Login
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        //Login does not have UserProfile fk
        //because it is the Principal of the relationship
        public UserProfile Profile { get; set; }
    }
