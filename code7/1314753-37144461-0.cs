        public static class Users
    {
        public static IEnumerable<kernel_Users> GetAll()
        {
            Kernel_Context db = new Kernel_Context();
            return db.kernel_Users;
        }
    public static kernel_Users Get(int userId)
        {
            Kernel_Context db = new Kernel_Context();
            return db.kernel_Users.Where(c => c.UserId == userId).FirstOrDefault();
        }
        ...
    }
