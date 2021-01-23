    void SaveTimer() 
    {
        try
        {
            using (Stream stream = new FileStream(filename, FileMode.Open))
            {
                yourTimer.Stop();
                Save();
                yourTimer.Start();
            }
        } 
        catch { Thread.Sleep(3000); }
        }
    }
