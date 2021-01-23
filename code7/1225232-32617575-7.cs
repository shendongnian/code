    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
        public static Context db { get; set; }
        public ApplicationUser()
        {
        }
        public ApplicationUser(int userId)
        {
            ApplicationUser user = ApplicationUser.Select(userId);
            this.FirstName = user.FirstName; 
            this.ApplicationRole = user.ApplicationRole; //database will be hit here
        }
        public static ApplicationUser Select(int userId)
        {
            //this uses EF to return an Application User object
            return db.Users.Find(userId);
        }
    }
    public class ApplicationRole
    {
        public int ApplicationRoleId { get; set;}
        public string Name { get; set; }
    }
