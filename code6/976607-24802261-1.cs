    public static class SQL
    {
        static IDatabase db = DatabaseAccessFactory.Instance.GetDatabaseAccess();
        public static User GetUserData(int userId)
        {
            return db.GetUserData(userId);
        }
        public static void InsertData(String dataStr1, String dataStr2)
        {
            db.InsertData(dataStr1, dataStr2);
        }
    }
