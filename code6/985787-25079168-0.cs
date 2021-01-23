    private static object _lockMe = new object();
    public static void WriteLine(string writeLine, Status status)
    {
        lock(_lockMe)
        {
            if (Directory == null)
            {
                CheckandCreateLogDirectory(".\\Log\\"); 
            }
            using (System.IO.StreamWriter objWriter = new System.IO.StreamWriter(Directory + "Log" + DateTime.Now.ToString("ddMMyyyy") + ".log", true))
            {
                objWriter.WriteLine(string.Format("[{0}] {1}\t{2}", DateTime.Now, status.ToString(), writeLine));             
            }
        }
    }
