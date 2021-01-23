    public class MyContext : DbContext {
        public MyContext()
            : base(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString)
        {
        }
    }
