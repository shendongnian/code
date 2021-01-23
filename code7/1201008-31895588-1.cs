    public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
    {
        if (DateTime.UtcNow > context.Trigger.EndTimeUtc)
            return;
        context.Scheduler.RescheduleJob(context.Trigger.Key, context.Trigger);
    }
