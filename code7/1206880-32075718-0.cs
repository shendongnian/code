    public static void logPageCreator()
            {
                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "logFile.txt"))
                {
                    System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "logFile.txt");
                }
                else 
                {
                    //File already exists moving on.....
                }
            }
