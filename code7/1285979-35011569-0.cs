    // Event may raise immediately before continung thread excecution so must be at the end
    taskInstance.Canceled += new BackgroundTaskCanceledEventHandler(OnCanceled);
    private void OnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
    {
        try
        {
            // Shutdown media pipeline
            BackgroundMediaPlayer.Shutdown();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
    
        deferral.Complete(); // signals task completion. 
    }
