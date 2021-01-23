    public class MyController: Controller
    {
        private IOptions<AppSettingsModel> settings;
    
        public MyController(IOptions<AppSettingsModel> settings)
        {
            this.settings = settings;
        }
    }
