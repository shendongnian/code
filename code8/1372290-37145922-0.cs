    public class UserInfo
        {
            private User User { get; set; }
    
            public int UserId
            {
                get { return User.UserId; }
                set { User.UserId = value; }
            }
    
            public string UserName
            {
                get { return User.UserName; }
                set { User.UserName = value; }
            }
    
            public string Email { get; set; }
    
    
    
            public UserInfo()
            {
                User = new User();
            }
        }
