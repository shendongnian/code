    public class FileLogger : BaseLogger
    {
        public FileLogger(string filename)
        {
            //initialize the file, etc
        }
        public override void LogException(Exception ex)
        {
            var string = GetStringFromException(ex);
            File.WriteAllLines(...);
        }
        public override void LogException(Exception ex)
        {
            var string = GetStringFromUserMessage(ex);
            File.WriteAllLines(...);
        }
    }
