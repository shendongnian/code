    public void EndInit()
    {
        Monitor.Enter(this.lockObj);
        try
        {
            this.initCount--;
            if (this.initCount == 0) {
                this.IsInitializing = false;
                this.IsInitialized = true;
                this.OnInitialized();
            }
        } 
        finally
        {
            Monitor.Exit(this.lockObj);    
        }
    }
