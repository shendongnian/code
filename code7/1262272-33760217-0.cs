    static List<User> users = null;
        static void Main(string[] args)
        {
            users = new List<User>();
            User user1 = new User("User2","User1");
            User user2 = new User("User3", "User1");
            User user3 = new User("User4", "User3");
            User user4 = new User("User5", "User2");
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            users.Add(user4);
            List<User> subUsersList = new List<User>();
            SubUsersHierarchy("User1", subUsersList, 1, 10);
            foreach (User user in subUsersList)
            {
                Console.WriteLine(user.UserID);
            }
        }
        public static void SubUsersHierarchy(string userid, List<User> subUsersList, int currentLevel, int maxLevel)
        {
            if (currentLevel > maxLevel)
                return;
            List<User> subUsers = GetSubUsers(userid);
            if (subUsers.Count == 0)
                return;
            int index = 0;
            for (index = 0; index < subUsers.Count; index++)
            {
                User user = subUsers[index];
                subUsersList.Add(user);
                SubUsersHierarchy(user.UserID, subUsersList, currentLevel + 1, maxLevel);
            }
        }
        public static List<User> GetSubUsers(string userid)
        {
            List<User> subusers = new List<User>();
            foreach (User user in users)
            {
                if (user.ParentUserID == userid)
                    subusers.Add(user);
            }
            return subusers;
        }
    }
