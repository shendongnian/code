    private void LogException(Exception ex)
        {
            try
            {
                File.AppendAllText(ServiceLogFilePath, System.Environment.NewLine + DateTime.Now + ":- Main Exception:");
                File.AppendAllText(ServiceLogFilePath, System.Environment.NewLine + ex.Message);
                File.AppendAllText(ServiceLogFilePath, System.Environment.NewLine + ex.StackTrace);
                File.AppendAllText(ServiceLogFilePath, System.Environment.NewLine + System.Environment.NewLine + "Inner Exception:");
                File.AppendAllText(ServiceLogFilePath, System.Environment.NewLine + ex.InnerException.Message);
                File.AppendAllText(ServiceLogFilePath, System.Environment.NewLine + ex.InnerException.StackTrace);
            }
            catch
            {
            }
        }
