    public class MyController: Controller
    {
        IOptions<AppSettingsModel> settings;
    
        public MyController(IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
        }
    }
