    public class ClientClass
    {
        private readonly MySettings _settings;
        public ClientClass(MySettings settings)
        {
             _settings = settings;
        }
        public void UpdateSettings()
        {
             _settings.SomeSetting = myNewSetting; // reset them however you need to here
        }
    }
