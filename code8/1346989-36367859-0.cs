    private void checkbr() 
    {
        try
        {
            while (true) 
            {
                var RunningProcessPaths = ProcessFileNameFinderClass.GetAllRunningProcessFilePaths();
                if (RunningProcessPaths.Contains("chrome.exe"))
                {   
                    Thread.Sleep(5000);
                }
                else
                {             
                    System.Threading.Thread.Sleep(500);
                    // TO START NEW INSTANCE OF APP
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    Thread.Sleep(500);
                    Process.GetCurrentProcess().Kill();
                }
            }            
        }
        catch (Exception)
        {
        }
    }
