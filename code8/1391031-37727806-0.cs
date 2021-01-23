    // All instantiated jobs should be added to this list, regardless of whether they're running.
    public static List<BaseJob> AllJobs { get; private set; }
    
    // These jobs must be running for the current job to start:
    public List<BaseJob> MustBeRunning { get; private set; }
    
    // These jobs must not be running for the current job to start:
    public List<BaseJob> CannotBeRunning { get; private set; }
    
    // This overrides the previous two lists to indicate whether the
    // job must not run concurrently with any other job (prevents you
    // from having to add every other job to "CannotBeRunning":
    public bool MustRunIndependently { get; set; }
    
    // Update your run method to take all of this into consideration:
    public void Run()
    {
        if (MustRunIndependently)
        {
            if (AllJobs.Any(x => x.IsRunning))
            {
                throw new InvalidOperationException("This job must run independently.");
            }
        }
        else if (MustBeRunning.Any(x => !x.IsRunning))
        {
            throw new InvalidOperationException("Required concurrent jobs are not running.");
        }
        else if (CannotBeRunning.Any(x => x.IsRunning))
        {
            throw new InvalidOperationException("Incompatible jobs are currently running.");
        }
        // If we made it here, then it's okay to run the job.
        IsRunning = true;
        RunInner(); // overrided by inheritors to perform actual job work.
        IsRunning = false;
    }
    
        
