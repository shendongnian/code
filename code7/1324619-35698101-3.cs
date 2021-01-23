    private void LogException(Exception ex)
        {
            try
            {
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + DateTime.Now + ":- Main Exception:");
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + ex.Message);
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + ex.StackTrace);
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + System.Environment.NewLine + "Inner Exception:");
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + ex.InnerException.Message);
                File.AppendAllText("LogFile.txt", System.Environment.NewLine + ex.InnerException.StackTrace);
            }
            catch
            {
            }
        }
