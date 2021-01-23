    public StreamReader file;
    public StreamReader file2;
    private string filewl1; //file paths
    private string filewl2; //file paths
    public void TimerStart()
    {
         systemTimer.Interval = 128;
         systemTimer.Elapsed += systemTimer_Elapsed;
         systemTimer.Enabled = true;
         FileStream fileStream = File.Open(filewl1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                file = new StreamReader(fileStream);
         FileStream fileStream2 = File.Open(filewl2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
         file2 = new StreamReader(fileStream2);
    }
    
    private void systemTimer_Elapsed(Object source,  System.Timers.ElapsedEventArgs e)
    { 
         if (!file.EndOfStream)
         {
              linewl1 = file.ReadLine();
              linewl2 = file2.ReadLine();  
    
              // ... do something 
         }
    }
