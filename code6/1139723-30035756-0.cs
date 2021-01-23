    public class MyUserInfo
    {
        //change it from Id to AppUserId
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        //add this virtual property
        public virtual AppUser User { get; set; }
    }
