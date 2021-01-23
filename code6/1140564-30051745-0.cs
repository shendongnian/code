    public class MainController
    {
        private DatabaseController databaseController;
        private UserDBController userDBController;
        private static MainController MCinstance = null;
        
        static MainController()
        {
            MCinstance = new MainController();
            MCinstance.databaseController = new DatabaseController();
            MCinstance.userDBController = new UserDBController();
        }
        public static MainController Instance
        {
            get
            {               
                return MCinstance;
            }
        }
        public UserDBController GetUserDBController()
        {
            return userDBController;
        }
        public DatabaseController GetDBController()
        {
            return databaseController;
        }
    }
