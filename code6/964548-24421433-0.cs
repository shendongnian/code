    namespace MyApplication.Core
    {
        public class MySession
        {
            private const string _SessionName = "__MY_SESSION__";
            
            private MySession() { }
            
            public static MySession Current
            {
                get
                {
                    MySession session =
                      (MySession)HttpContext.Current.Session[_SessionName];
                    if (session == null)
                    {
                        session = new MySession();                
                        HttpContext.Current.Session[_SessionName] = session;
                    }
                    return session;
                }
            }        
            public UserModel CurrentUser { get; set; }
           
        }
    }
