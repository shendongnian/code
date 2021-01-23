    public void RunTask()
    {
        bool canRunTask = true;
    
        // Check if another instance of this method is currently executing.  If so, do not execute the rest of this method
        if (this.isTaskRunning)
        {                                       // <-- ___MARK___
            canRunTask = false;
        }
        else
        {
            lock (this.runTaskLock)
            {
                if (this.isTaskRunning)
                {
                    canRunTask = false;
                }
                else
                {
                        this.isTaskRunning = true;
                }
            }
        }
    
        // Call DoTheThing if another instance is not currently outstanding
        if (canRunTask)
        {
            try
            {
                Task task = new Task(() => DoTheThing());
                task.Start();
            }
            catch (Exception ex)
            {
                // Handle the exception
            }
            finally
            {
                this.isTaskRunning = false;
            }
        }
    }
