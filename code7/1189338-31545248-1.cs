    public override void Initialize(System.Action onInitializeCallback = null)
    {   
            If (BackgroundEntityWorker.RunWorkerCompleted != null)
            {
                BackgroundEntityWorker.RunWorkerCompleted();
            }    
    }
