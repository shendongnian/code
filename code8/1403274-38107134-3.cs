    public class ClassThatNeedsSettings
    {
        private readonly IMySettings _settings;
        
        public MySettings(IMySettings settings)
        {
            _settings = settings;
        }
    }
