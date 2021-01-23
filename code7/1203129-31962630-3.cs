    private bool WaitForFile(FileInfo file)
    {
        var attemptCount = 0;
        while(true)
        {
            try
            {
                using(file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)) 
                { 
                    return true; 
                }
            }
            catch (IOException)
            {
                //File isn't ready yet, so we need to keep on waiting until it is.
            }
            //We'll want to wait a bit between polls, if the file isn't ready.
            attemptCount++;
                
            if(attemptCount > 5)
            {
                break;
            }
                
            Thread.Sleep(1000);
        }
        return false;
    }
