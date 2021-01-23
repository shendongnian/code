      private static void AddtoLogFile(string Message)
        {
            string LogPath = @"D:\Logfile\";
            string filename = "Log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string filepath = LogPath + filename;
            if (File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filepath, false))
                {
                   using(StreamWriter writer1 = File.CreateText(filepath))
                    {
                       if(File.Exists(filepath))
                       {
                           writer.WriteLine(Message);
                       }
                    }
                    //StreamWriter writer1 = File.CreateText(filepath);
                    //writer.WriteLine(Message);
                }
