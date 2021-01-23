    public void EndInit()
    {
        bool lockAcuired = false;
        try
        {
            Monitor.Enter(this.lockObj, ref lockAquired);
            this.initCount--;
            if (this.initCount == 0) {
                this.IsInitializing = false;
                this.IsInitialized = true;
                this.OnInitialized();
            }
        } 
        finally
        {
            if(lockAquired)
                Monitor.Exit(this.lockObj);    
        }
    }
