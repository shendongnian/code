       private void addtimer()
    {
        timer = new System.Timers.Timer();
        timer.Interval = (1000) * 60 * 60;//(10000) * 6;
        timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        timer.Enabled = true;
        timer.Start();
    }
    protected void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        Deletefile();
    }
    private void Deletefile()
    {
        try
        {
            string FilePath = System.Configuration.ConfigurationSettings.AppSettings["FilePath"];
            DirectoryInfo dirInfo = new DirectoryInfo(FilePath);
            foreach (DirectoryInfo subDirectory in dirInfo.GetDirectories())
            {
                if (subDirectory.Name != "Temp" && subDirectory.CreationTime < DateTime.Now.AddDays(-1))
                    subDirectory.Delete(true);
            }
        }
        catch (Exception ex)
        {
        }
    }
