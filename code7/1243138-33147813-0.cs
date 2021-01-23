    public interface IAppConfguration
    {
        String MyConnectionString { get; }
        String ServerPath { get; }
    }
    public class AppConfiguration
    {
        private readonly HttpContext context;
        public AppConfiguration(HttpContext context)
        {
            this.context = context;
        }
        public String MyConnectionString
        {
            get { return COnfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }
        public String ServerPath
        {
            get { return context.Server.MapPath("~/"); }
        }
    }
