    public class MyHelper : IMyHelper
    {
        private readonly ProfileOptions _options;
    
        public MyHelper(IOptions<ProfileOptions> options)
        {
            _options = options.Value;
        {
    
        public bool CheckIt()
        {
            return _options.SomeBoolValue;
        }
    }
