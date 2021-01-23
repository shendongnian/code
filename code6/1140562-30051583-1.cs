        public class MainController 
        {
            private static DatabaseController databaseController;
            private static UserDBController userDBController;
            private static MainController MCinstance = null;
            private MainController()
            {
            }
            public static MainController Instance
            {
                get
                {
                    if (MCinstance == null)
                    {
                        MCinstance = new MainController();
                        databaseController = new DatabaseController();
                        userDBController = new UserDBController();
                    }
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
