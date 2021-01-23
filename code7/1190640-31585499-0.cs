    public static void WriteLog(string Error)
    {
        using (StreamWriter logfile = new StreamWriter(filePath + "Log.txt", true))
        {
            logfile.WriteLine(DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString() + " -@: " + Error);
            logfile.Close();
        }
    }
