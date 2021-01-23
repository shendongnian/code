    public class Global : HttpApplication {
        public static IDatabase Cache = CacheConnectionHelper.Connection.GetDatabase();
        void Application_Start(object sender, EventArgs e) {
        
        }
        .....
    }
