    public class Deployment
    {
         private AppPoolSettings appPool;
    
         public AppPoolSettings AppPool
         {
             get { return appPool; }
             set
             {
                 // if (appPool == null)
                 //    appPool = new AppPoolSettings();
                 appPool = value;
             }
         }
    
         private WebSiteSettings site;
    
         public WebSiteSettings Site
         {
             get { return site; }
             set
             {
                 // if (site == null)
                 //    site = new WebSiteSettings();
                 site = value;
             }
         }
    
         public Deployment()
         {
             // No instatiation anymore...         
         }
     }
