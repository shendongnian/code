    public class Startup
    {
        //20160718 JPC enable portable dev database
        private string _contentRootPath = "";
    
        public Startup(IHostingEnvironment env)
        {
            //20160718 JPC enable portable dev database
            _contentRootPath = env.ContentRootPath;
        ...
        }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //20160718 JPC enable portable dev database
            string conn = Configuration.GetConnectionString("DefaultConnection");
            if(conn.Contains("%CONTENTROOTPATH%"))
            {
                conn = conn.Replace("%CONTENTROOTPATH%", _contentRootPath);
            }
            ...
         }
