    public class ClassThatNeedsSettings
    {
        private readonly IMySettings _settings;
        
        public ClassThatNeedsSettings(IMySettings settings)
        {
            _settings = settings;
        }
    }
