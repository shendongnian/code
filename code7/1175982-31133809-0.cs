    public class HomeController : Controller
    {    
        readonly ISettingsManager settingsManager;
    
        public HomeController(ISettingsManager settingsManager )
        {
            if(settingsManager == null)
                throw new ArgumentNullException("settingsManager is null");
    
            this.settingsManager = settingsManager;
        }
    }
