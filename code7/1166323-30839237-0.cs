    catch (Exception ex)
        {
            
            if (LogWriter != null)
            {
                LogWriter.Close();     
            }
            LogWriter = File.AppendText(logFile);
            LogWriter.WriteLine("\n Error : {0}" + ex.ToString());
        }
