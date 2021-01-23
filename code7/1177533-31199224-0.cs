    public class Session
    {
        public String UserName { get; set; }
    
        public String Token { get; set; }
    }
    public class SessionManager
    {
        private static Session _session; 
    
        public static Session CurrentSession
        {
            get
            {
                return _session;
            }
        }
    
        public static void Login(string username, string password)
        {
            // login the user
            _session = new Session();
        }
    }
