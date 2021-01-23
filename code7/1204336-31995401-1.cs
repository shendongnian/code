    public async Task<bool> PreparePSOAndRunPSO()
    {
        string[] params;
        //code to fetch the parameters
        PSOHelper psoH = new PSOHelper (params)
        try
        {
            var task = psoH.RunApp(RunConfig.RunMode); //no need to use Task.Run considering the method returns a task.
            
            while (!task.IsCompleted)
            {
                /* open stream as readonly, read the log, close the stream */
                /* if the log isn't to big, you can read to end so you close the stream faster and then parse the entire log on each iteration.  If the log is big, you'd need to read it line by line and parse each line */                 
                /* maybe do a await Task.Delay(100); if you have any race conditions */
                
            }
            return true;
        }
        catch( Exception ex)
        {
            Helper.log.Error("exception starting PSO", ex);
            return false;
        }
    }
