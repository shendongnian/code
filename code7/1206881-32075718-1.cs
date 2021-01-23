    public static void Log(string message)
            {
                try
                {  
                    System.IO.StreamWriter file = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "logFile.txt",true);
                    file.WriteLine(message);
                    file.Close();
    
                    long size = new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "logFile.txt").Length;
                    if (size > 5000000)// limits the text file size to this many bytes
                    {
                        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "logFile.txt", String.Empty);
                    }
                }
                catch
                {
    
                }
            }
