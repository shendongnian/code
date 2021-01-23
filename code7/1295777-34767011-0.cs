        namespace CustomLogging
        {
        public class CustomAppender : log4net.Appender.RollingFileAppender
          {
            protected override void OpenFile(string fileName, bool append)
            {
              string baseDirectory = Path.GetDirectoryName(fileName);
              string fileNameOnly = Path.GetFileName(fileName);
              string newDirectory = Path.Combine(baseDirectory, DateTime.Now.ToString("yyyyMMdd"));
              string newFileName = Path.Combine(newDirectory, fileNameOnly);
        
              base.OpenFile(newFileName, append);
            }
          }
    }
