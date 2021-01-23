    public class MyService : IMyService
    {
        private readonly MySettings settings;
        public MyService(IOptions<MySettings> mysettings) 
        {
            this.settings = mySettings.Value;
        }
    }
