    public static class ActionLog
    {
        const string ACTIONLOGFILEIDENTIFIER = "ActionLog_"; 
        private static int _numberOfDaily = 0;
        private static int _maxNumerOfLogsInMemory = 512;
        private static List<string> _TheUserActions = new List<string>();
        private static string _actionLoggerDirectory = string.Empty;
    
        public static void LogActionSetUp(int maxNumerOfLogsInMemory = 512,string actionLoggerDirectory = "")
        {  
            if (string.IsNullOrEmpty(actionLoggerDirectory)) actionLoggerDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\ProjectNameMgtFolder\\";
            if (!Directory.Exists(actionLoggerDirectory)) Directory.CreateDirectory(actionLoggerDirectory);
            _actionLoggerDirectory = actionLoggerDirectory;
            
            LogAction("MDI_Form", "APPLICATION", "STARTUP", string.Empty);
        }
    
        public static void LogAction(string frmName, string ctrlName, string eventName, string value)
        {
            if (value.Length > 10) value = value.Substring(0, 10);
            LogAction(DateTime.Now, frmName,ctrlName, eventName, value);
        }
    
        public static void LogAction(DateTime timeStamp, string frmName, string ctrlName, string eventName, string value)
        {
            _TheUserActions.Add(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", timeStamp.ToShortTimeString(), frmName, ctrlName, eventName, value));
            if (_TheUserActions.Count > _maxNumerOfLogsInMemory) WriteLogActionsToFile();
        }
    
        public static string GetLogFileName()
        {
            //Check if the current file is > 1 MB and create another
            string[] existingFileList = System.IO.Directory.GetFiles(_actionLoggerDirectory, ACTIONLOGFILEIDENTIFIER +  DateTime.Now.ToString("yyyyMMdd") + "*.log");
    
            string filePath = _actionLoggerDirectory + ACTIONLOGFILEIDENTIFIER + DateTime.Now.ToString("yyyyMMdd") + "-0.log";
            if (existingFileList.Count() > 0)
            {
                filePath = _actionLoggerDirectory + ACTIONLOGFILEIDENTIFIER + DateTime.Now.ToString("yyyyMMdd") + "-" + (existingFileList.Count() - 1).ToString() + ".log";
                FileInfo fi = new FileInfo(filePath);
                if (fi.Length / 1024 > 1000) //Over a MB (ie > 1000 KBs)
                {
                    filePath = _actionLoggerDirectory + ACTIONLOGFILEIDENTIFIER + DateTime.Now.ToString("yyyyMMdd") + "-" + existingFileList.Count().ToString() + ".log";
                }
            }
            return filePath;
        }
    
        public static string[] GetTodaysLogFileNames()
        {
            string[] existingFileList = System.IO.Directory.GetFiles(_actionLoggerDirectory, ACTIONLOGFILEIDENTIFIER + DateTime.Now.ToString("yyyyMMdd") + "*.log");
            return existingFileList;
        }
    
        public static void WriteLogActionsToFile()
        {
            string logFilePath = GetLogFileName();
            if (File.Exists(logFilePath)) {
                File.AppendAllLines(logFilePath,_TheUserActions);
            }
            else {
                File.WriteAllLines(logFilePath,_TheUserActions);
            }
            _TheUserActions = new List<string>();
        }
    }
