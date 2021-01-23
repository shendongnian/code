    public class SqlHandler
    {
        private readonly string m_LogFileNameAndPath = @"C:\log.txt";
        // or get it from AppConfig, as noted by FirebladeDan
    
        public void ProcessData() { /*...*/ }
    
        public void OnInfoMessage(object sender, SqlInfoMessageEventArgs args)
        {
            foreach(var err in args.Errors)
            {
                File.AppendAllText(m_LogFileNameAndPath, err.Message);
            }
        }
    }
