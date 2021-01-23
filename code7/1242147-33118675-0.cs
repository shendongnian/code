    public void StartupJob()
    {
        this.Job = new Job(#params); //create the object
        this.Job.JobCompleted += Job_JobCompleted; //hookup the event
        this.Job.Run(); //do some work
    }
    
    public override void SendNotification(string content)
    {
        //Invoke your event (always see if it is hooked up)
        if(Job.JobCompleted != null)
            Job.JobCompleted(this, new JobCompletionData(content));
    }
