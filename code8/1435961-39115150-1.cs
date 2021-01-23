    public class Logger
    {
        public Logger(IFileWrapper fileWrapper)
        {
            FileWrapper = fileWrapper;
        }
        public IFileWrapper FileWrapper { get; }
    }
    // in your test:
    var logger = new Logger(mock.Object);
