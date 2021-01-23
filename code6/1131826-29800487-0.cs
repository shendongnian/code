    public class MyConfigs
    {
        public virtual object Username
        {
            get { return HttpContext.Current.Application["Username"]; }
            set { } 
        }
        public static MyConfigs GetConfig()
        {
            return new MyConfigs();
        }
        protected MyConfigs()
        {
            
        }
    }
