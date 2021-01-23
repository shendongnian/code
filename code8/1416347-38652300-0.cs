    public void ScheduleXeroMonitor()
    {            
        //var backGroundWorker = DependencyResolver.Current.GetService<IXeroBackGroundWorker>();  --> let hangfire and autofac do this for you          
        RecurringJob.AddOrUpdate<IXeroBackGroundWorker>("XeroPolling", backGroundWorker => backGroundWorker.PollJobs(), Cron.Minutely); //change the Cron to every 5 minutes    
        //var emailWorker = DependencyResolver.Current.GetService<IEmailService>();--> let hangfire and autofac do this for you          
        RecurringJob.AddOrUpdate<IEmailService>("EmailPolling", emailWorker => emailWorker.SendQueuedEmails(), Cron.Minutely);//"*/10 * * * *"
    }
