    public class ThirdPartyLoader : IFileLoader
    {
        public bool Load(string fileName)
        {
            // simply acts as a wrapper around your 3rd party tool
        }
    }
    public class SmartLoader : IFileLoader
    {
        private readonly ICanSetStatus _statusSetter;
        public SmartLoader(ICanSetStatus statusSetter)
        {
            _statusSetter = statusSetter;
        }
        public bool Load(string fileName)
        {
            _statusSetter.SetStatus(FileStatus.Started);
            // do whatever's necessary to load the file ;)
            _statusSetter.SetStatus(FileStatus.Done);
        }
    }
