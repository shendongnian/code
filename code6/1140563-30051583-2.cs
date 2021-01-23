        public class MainController 
        {
            private DatabaseController databaseController = new DatabaseController();
            private UserDBController userDBController = new UserDBController();
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
