    static void Main(string[] args)
    {
    List<User> myUserList = GetUserList();
    }
    public static List<User> GetUserList()
            {
                var dbContext = new UserEntities();
                var results = dbContext.GetUserDetails();
                return results.Select(x => new User
                {
                    User_id = x.User_id,
                    First_Name = x.First_Name,
                    Last_Name = x.Last_NAME
                }).ToList();
            }
