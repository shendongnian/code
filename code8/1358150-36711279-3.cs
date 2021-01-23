    public void EndInit()
    {
        lock(this.lockObj)
        {
            this.initCount--;
            if (this.initCount == 0) {
                this.IsInitializing = false;
                this.IsInitialized = true;
                this.OnInitialized();
            }
        }
    }
