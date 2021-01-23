    public static class MainController 
    {
        private static DatabaseController databaseController;
        private static UserDBController userDBController;
    	
        static MainController()
        {
            databaseController = new DatabaseController();
            userDBController = new UserDBController();
        }
        public static UserDBController GetUserDBController()
        {
            return userDBController;
        }
        public static DatabaseController GetDBController()
        {
            return databaseController;
        }
    }
