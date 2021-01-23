    public class BaseUser
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
    }
    public class User : BaseUser
    {
        public string LastName { get; set; }
        public int AccessLevelID { get; set; }
        public List<Groups> UserGroups { get; set; }
    }
