        string path = @"C:\SomePath\MyLogFile.txt";
        public static string Log(string Message)
        {
            try
            {
                if (File.Exists(path) == false)
                    File.Create(path).Close();  // need this .Close()!!!
                logCounter++;
                string logString = logCounter + "   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ": " + Message + Environment.NewLine;
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(logString);
                    }
                }
                return logString; // only necessary so we can return an error in the Exception block
            }
            catch (Exception ex)
            {
                return "Logger:  Cannot log data. " + ex.ToString();
            }
        }
