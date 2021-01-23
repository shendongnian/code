    AutoResetEvent waitHandle = new AutoResetEvent(false);
    int nVerNoGlobalTempHolder = 0;
    
    private int GetVersionNumber(string i_sFileName)
    {
        #region Get latest version no.
        for (int i = 0; i < 10 && nVerNoGlobalTempHolder != 0; i++)
        {
           //Someone is waiting for this callback already...
           //Do something like:
           Thread.Sleep(500);
        }
        If (nVerNoGlobalTempHolder == 0) throw new Exception("timeout");
    
       // RequestResult result;
        try
        {
    
        OAuthUtility.GetAsync
           (
           "https://api.dropboxapi.com/1/revisions/auto/",
               new HttpParameterCollection
                            {
                               { "path", i_sFileName },
                               { "access_token", accessToken },
                               { "rev_limit", 1 }
                            },
              callback:  GetFilesRevisions_Results ??? How I can access return variable 
           );
        }
        catch
        { 
         
        }
        waitHandle.WaitOne();
        int nVerNo =nVerNoGlobalTempHolder;
    
        nVerNoGlobalTempHolder = 0;//Reset this in case you have multiple thread calling it
        return nVerNo;    
    }
    
    
    private int GetFilesRevisions_Results(RequestResult result)
    {
        if (result.StatusCode == 200)
        {
            dynamic dynJson = JsonConvert.DeserializeObject(Convert.ToString(result));
            foreach (var item in dynJson)
            {
                nVerNoGlobalTempHolder = Convert.ToInt32(item.rev);
            }
    
        }
        else
        {
            throw new Exception("Failed to get revisions of files");
        }
        WaitHandle.Set();
        
    }
