    public static class FileWrapperFactory
    {
        private static IFileWrapper _fileWrapper;
        public static IFileWrapper GetInstance()
        {
            return _fileWrapper ?? (_fileWrapper = CreateInstance());
        }
        private static IFileWrapper CreateInstance()
        {
            // do all the necessary setup here
            return new FileWrapper();
        }
    }
    public class StuffDoer
    {
        public void DoStuff()
        {
            var logger = new FileLogger(FileWrapperFactory.GetInstance());
            logger.WriteLog("Starting to do stuff...");
            // do stuff
            logger.WriteLog("Stuff was done.");
        }
    }
